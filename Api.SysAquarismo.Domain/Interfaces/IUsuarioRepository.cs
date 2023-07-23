using Api.SysAquarismo.Domain.Models.Usuario;

namespace Api.SysAquarismo.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task InsertUsuario(Usuario usuario);
        Task<dynamic> LoginUsuario(Usuario usuario);
        Task GetUsuario(string nm_usuario);
        Task ResetSenha(Usuario usuario);
    }
}
