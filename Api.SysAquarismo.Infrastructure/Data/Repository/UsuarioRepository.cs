using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models.Usuario;
using Api.SysAquarismo.Infrastructure.Data.Context;

namespace Api.SysAquarismo.Infrastructure.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;
        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }
        public Task GetUsuario(string nm_usuario)
        {
            throw new NotImplementedException();
        }

        public async Task InsertUsuario(Usuario usuario)
        {
            try
            {
                await _context.AddAsync(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<dynamic> LoginUsuario(Usuario usuario)
        {
            try
            {
                return _context.Usuarios.Where(x => x.Ds_Nome_Usuario == usuario.Ds_Nome_Usuario && x.Ds_Senha == usuario.Ds_Senha).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task ResetSenha(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
