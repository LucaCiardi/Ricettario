using Microsoft.EntityFrameworkCore;
using Ricettario.Models;


namespace Ricettario.Data
{
    public class RicettarioContext : DbContext
    {
        public RicettarioContext(DbContextOptions<RicettarioContext> options)
            : base(options)
        {
        }

        public DbSet<Ricetta> Ricette { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ricetta>(entity =>
            {
                entity.ToTable("Ricette");
                entity.HasKey(e => e.Id);
            });
        }
    }
}
