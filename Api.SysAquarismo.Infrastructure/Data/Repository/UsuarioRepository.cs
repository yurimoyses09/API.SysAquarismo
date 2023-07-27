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
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            await _context.CloseConnection();
        }
    }

    public async Task<dynamic> LoginUsuario(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Task ResetSenha(Usuario usuario)
    {
        throw new NotImplementedException();
    }
}