using MDT.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MDT.Infrastructure.Persistence
{
    public class MdtContext : DbContext
    {
        public MdtContext(DbContextOptions<MdtContext> options) : base(options)
        {

        }

        public DbSet<Drone> Drones { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<DeliveryDetails> DeliveryDetails { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase(databaseName: "MediDroneTrnsDb");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Drone>(
        //    modelBuilder.ApplyConfiguration(new DroneConfiguration());
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
