using Microsoft.EntityFrameworkCore;

namespace DataInspector.API.Entities
{
    public class DataInspectorDbContext : DbContext
    {
        public DataInspectorDbContext(DbContextOptions options) : base(options)
        {
        }

        public DataInspectorDbContext()
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Sample> Samples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(new Project {
                Id = 1,
                Name = "Demo Project",
                Description = "This example shows SignalR synchrounizes samples among mobiles"
            });
        }
    }
}
