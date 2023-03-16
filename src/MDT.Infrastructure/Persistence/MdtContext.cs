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
    }
}
