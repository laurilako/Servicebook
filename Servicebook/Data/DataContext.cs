using Microsoft.EntityFrameworkCore;

namespace Servicebook.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=servicebook.db");
        }

        public DbSet<Servicebook.Models.Service> Services { get; set; }
        public DbSet<Servicebook.Models.Vehicle> Vehicles { get; set; }

    }
}
