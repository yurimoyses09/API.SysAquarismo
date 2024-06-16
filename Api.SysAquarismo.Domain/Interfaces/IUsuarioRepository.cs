using Api.SysAquarismo.Domain.Models;

namespace Api.SysAquarismo.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<int> InsertUsuario(Usuario usuario);
    Task<IEnumerable<Usuario>> LoginUsuario(Usuario usuario);
    Task GetUsuario(string nm_usuario);
    Task ResetSenha(Usuario usuario);
    Task<IEnumerable<Usuario>> BuscaMesmoLogin(Usuario usuario);
    Task<Usuario> BuscaDadosUsuario(string nome_usuario);
}
