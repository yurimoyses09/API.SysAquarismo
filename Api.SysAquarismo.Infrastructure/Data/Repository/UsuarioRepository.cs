using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models;
using Api.SysAquarismo.Infrastructure.Querys;

namespace Api.SysAquarismo.Infrastructure.Data.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IContext _context;
    public UsuarioRepository(IContext context)
    {
        _context = context;
    }

    public async Task<dynamic> BuscaDadosUsuario(string nome_usuario)
    {
        try
        {
            string queryUsuario = UsuarioQD.BuscaDadosUsuario();
            object parameters_usuario = new { nome_usuario };
            IEnumerable<Usuario> dataUser = _context.SelectAsync<Usuario>(queryUsuario, parameters_usuario).Result;

            int id_usuario = dataUser.FirstOrDefault().Id_Usuario;

            string queryPeixe = PeixeDQ.BuscaDadosPeixeLogin();
            object parameters_peixe = new { id_usuario };
            IEnumerable<Peixe> peixes = _context.SelectAsync<Peixe>(queryPeixe, parameters_peixe).Result;

            Usuario dados = new(peixes, dataUser.FirstOrDefault());

            return dados;
        }catch(ArgumentNullException)
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

    public async Task<dynamic> BuscaMesmoLogin(Usuario usuario)
    {
        try
        {
            string query = UsuarioQD.BuscaExistenciaLogin();

            object parameters = new
            {
                nome_login = usuario.Ds_Nome_Usuario_Login,
                usuario_ativo = 1
                
            };

            return _context.SelectAsync(query, parameters).Result;
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
                nome_usuario = usuario.Nome_Usuario,
                idade = usuario.Idade,
                telefone = usuario.Ds_Telefone,
                sexo = (int)usuario.Sexo,
                pais = usuario.Ds_Pais,
                nome_login = usuario.Ds_Nome_Usuario_Login,
                senha = usuario.Ds_Senha,
                senha_repetida = usuario.Ds_Senha,
                email = usuario.Ds_Email,
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

    public async Task<dynamic> LoginUsuario(Usuario usuario)
    {
        try
        {
            string query = UsuarioQD.BuscaUsuarioLogin();

            object parameters = new
            {
                nome_login = usuario.Ds_Nome_Usuario_Login,
                senha = usuario.Ds_Senha,
                usuario_ativo = 1
            };

            return _context.SelectAsync(query, parameters).Result;
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