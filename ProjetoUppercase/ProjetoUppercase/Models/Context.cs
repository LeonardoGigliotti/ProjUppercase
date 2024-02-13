using Microsoft.EntityFrameworkCore;

namespace ProjetoUppercase.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options):base(options) { 
        
        }

        public DbSet<Carro> Carro { get; set; }
        public DbSet<Pager> Pager { get; set; }
    }
}
