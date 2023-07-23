using Api.SysAquarismo.Domain.Models.Peixe;
using Microsoft.EntityFrameworkCore;

namespace Api.SysAquarismo.Infrastructure.Data.Context
{
    public class PeixeContext : DbContext
    {
        public PeixeContext(DbContextOptions<PeixeContext> options) : base(options)
        {
        
        }

        public DbSet<Peixe> Peixes { get; set; }
    }
}
