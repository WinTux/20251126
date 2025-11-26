using Microsoft.EntityFrameworkCore;

namespace Servidor.Contenido
{
    public class AppDbContext : DbContext
    {
        public DbSet<Servidor.Models.Plato> Platos => Set<Servidor.Models.Plato>();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
    }
}
