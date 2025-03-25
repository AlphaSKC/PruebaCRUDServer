using Microsoft.EntityFrameworkCore;
using PruebaCRUDServer.Models;

namespace PruebaCRUDServer.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
