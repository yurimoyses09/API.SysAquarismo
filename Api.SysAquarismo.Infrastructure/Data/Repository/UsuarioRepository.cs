using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models.Usuario;
using Api.SysAquarismo.Infrastructure.Querys.UsuarioQD;

namespace Api.SysAquarismo.Infrastructure.Data.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IContext _context;
    public UsuarioRepository(IContext context)
    {
        _context = context;
    }

    public async Task<List<dynamic>> BuscaDadosUsuario(string nome_usuario)
    {
        try
        {
            string query = UsuarioQD.BuscaDadosUsuario(nome_usuario);

            return (List<dynamic>) _context.SelectAsync(nome_usuario).Result;
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

            return _context.InsertAsync(query).Result;
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