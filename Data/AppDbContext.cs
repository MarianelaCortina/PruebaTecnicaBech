using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBech.Models;


namespace PruebaTecnicaBech.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();
    }
}
