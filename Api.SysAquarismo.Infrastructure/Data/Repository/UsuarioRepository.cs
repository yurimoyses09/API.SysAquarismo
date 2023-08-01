using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models;
using Api.SysAquarismo.Domain.Models.Usuario;
using Api.SysAquarismo.Infrastructure.Querys.UsuarioQD;
using Dapper;
using Microsoft.Data.SqlClient;

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
            string query = UsuarioQD.BuscaDadosUsuario(nome_usuario);
            using (var db = new SqlConnection(Environment.GetEnvironmentVariable("AMBIENTE_DB_DEV", EnvironmentVariableTarget.User)))
            {
                var lookup = new Dictionary<int, Usuario>();
                db.Query<Usuario, Peixe, Usuario>(
                    query,
                    (usuario, peixe) =>
                    {
                        if (!lookup.TryGetValue(usuario.Id_Usuario, out Usuario usuarioEntry))
                        {
                            usuarioEntry = usuario;
                            usuarioEntry.Peixes = new List<Peixe>();
                            lookup.Add(usuarioEntry.Id_Usuario, usuarioEntry);
                        }
                        usuarioEntry.Peixes.Add(peixe);
                        return usuarioEntry;
                    },
                    splitOn: "Id_Peixe"
                );

                return lookup.Values.ToList();
            }
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