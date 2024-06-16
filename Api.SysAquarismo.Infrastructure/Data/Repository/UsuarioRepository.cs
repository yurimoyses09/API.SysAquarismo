using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models;
using Api.SysAquarismo.Infrastructure.Querys;

namespace Api.SysAquarismo.Infrastructure.Data.Repository;

public class UsuarioRepository(IContext context) : IUsuarioRepository
{
    private readonly IContext _context = context;

    public async Task<Usuario> BuscaDadosUsuario(string nome_login)
    {
        try
        {
            string queryUsuario = UsuarioQD.BuscaDadosUsuario();
            object parameters_usuario = new { nome_login };
            IEnumerable<Usuario> dataUser = _context.SelectAsync<Usuario>(queryUsuario, parameters_usuario).Result;

            int id_usuario = dataUser.FirstOrDefault().id_usuario;

            string queryPeixe = PeixeDQ.BuscaDadosPeixeLogin();
            object parameters_peixe = new { id_usuario };
            IEnumerable<Peixe> peixes = _context.SelectAsync<Peixe>(queryPeixe, parameters_peixe).Result;

            Usuario dados = new(peixes, dataUser.FirstOrDefault());

            return dados;

        }
        catch (ArgumentNullException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await _context.CloseConnection();
        }
    }

    public async Task<IEnumerable<Usuario>> BuscaMesmoLogin(Usuario usuario)
    {
        try
        {
            string query = UsuarioQD.BuscaExistenciaLogin();

            object parameters = new
            {
                usuario.nome_login,
                usuario_ativo = 1
            };

            return _context.SelectAsync<Usuario>(query, parameters).Result;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await _context.CloseConnection();
        }
    }

    public async Task<int> InsertUsuario(Usuario usuario)
    {
        try
        {
            string query = UsuarioQD.QueryCriaUsuario();

            object parameters = new
            {
                usuario.nome_usuario,
                usuario.idade,
                usuario.telefone,
                usuario.sexo,
                usuario.pais,
                usuario.nome_login,
                usuario.senha,
                senha_repetida = usuario.senha,
                usuario.email,
                status_usuario = 1,
                dt_inclusao = DateTime.Now
            };

            return _context.InsertAsync(query, parameters).Result;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await _context.CloseConnection();
        }
    }

    public async Task<IEnumerable<Usuario>> LoginUsuario(Usuario usuario)
    {
        try
        {
            string query = UsuarioQD.BuscaUsuarioLogin();

            object parameters = new
            {
                usuario.nome_login,
                usuario.senha,
                usuario_ativo = 1
            };

            return _context.SelectAsync<Usuario>(query, parameters).Result;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await _context.CloseConnection();
        }
    }

    #region [ Não Implementado ]
    public Task ResetSenha(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Task GetUsuario(string nm_usuario)
    {
        throw new NotImplementedException();
    }
    #endregion
}