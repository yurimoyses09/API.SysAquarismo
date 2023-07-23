using Api.SysAquarismo.Domain.Models.Usuario;
using Microsoft.EntityFrameworkCore;

namespace Api.SysAquarismo.Infrastructure.Data.Context
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base (options)
        {
        
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
