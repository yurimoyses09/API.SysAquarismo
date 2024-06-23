using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models;
using Api.SysAquarismo.Infrastructure.Querys;

namespace Api.SysAquarismo.Infrastructure.Data.Repository;

public class UsuarioRepository(IContext context) : IUsuarioRepository
{
    private readonly IContext _context = context;

    public async Task<IEnumerable<Usuario>> BuscaDadosUsuario(string nome_login)
    {
        try
        {
            string query = UsuarioQD.BuscaDadosUsuario();
            object parameters_usuario = new { nome_login };

            return await _context.SelectManyAsync<Usuario, Peixe, int>(query, parent => parent.id_usuario, child => child.id_peixe, (parent, child) => parent.peixes.Add(child), parameters_usuario, "id_peixe");
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