using Api.SysAquarismo.Domain.Models;

namespace Api.SysAquarismo.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<int> InsertUsuario(Usuario usuario);
    Task<dynamic> LoginUsuario(Usuario usuario);
    Task GetUsuario(string nm_usuario);
    Task ResetSenha(Usuario usuario);
    Task<dynamic> BuscaMesmoLogin(Usuario usuario);
    Task<Usuario> BuscaDadosUsuario(string nome_usuario);
}
