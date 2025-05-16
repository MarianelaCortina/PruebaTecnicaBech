using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBech.Models;


namespace PruebaTecnicaBech.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<Component> Components { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Machine>()
                .HasMany(m => m.Components)
                .WithOne(c => c.Machine)
                .HasForeignKey(c => c.MachineId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
