using HorseRaceBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace HorseRaceBackend.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Horse> Horses { get; set; }
        public DbSet<Bettor> Bettors { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Horse>()
                .HasMany(h => h.Bettors)
                .WithOne()
                .HasForeignKey(b => b.HorseId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Bettor>()
                .Property(b => b.Bet)
                .HasPrecision(10, 2);
        }
    }
}
