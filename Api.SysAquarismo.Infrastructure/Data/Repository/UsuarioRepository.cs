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
            string queryUsuario = UsuarioQD.BuscaDadosUsuario(nome_usuario);
            object param = new { nome_usuario };
            IEnumerable<Usuario> dataUser = _context.SelectAsync<Usuario>(queryUsuario, param).Result;

            int id_usuario = dataUser.FirstOrDefault().Id_Usuario;

            string queryPeixe = PeixeDQ.BuscaDadosPeixeLogin(id_usuario);
            object parametros_peixe = new { id_usuario };
            IEnumerable<Peixe> peixes = _context.SelectAsync<Peixe>(queryPeixe, parametros_peixe).Result;

            var dados = new Usuario(peixes, dataUser.FirstOrDefault());

            return dados;
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
            string query = UsuarioQD.BuscaExistenciaLogin(usuario);

            return _context.SelectAsync(query).Result;
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

    public Task GetUsuario(string nm_usuario)
    {
        throw new NotImplementedException();
    }

    public async Task<int> InsertUsuario(Usuario usuario)
    {
        try
        {
            string query = UsuarioQD.QueryCriaUsuario(usuario);

            object parameters = new { }; 

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
            string query = UsuarioQD.BuscaUsuarioLogin(usuario);

            return _context.SelectAsync(query).Result;
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

    public Task ResetSenha(Usuario usuario)
    {
        throw new NotImplementedException();
    }
}