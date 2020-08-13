using CifSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CifSQL.Data
{
    public class CifSQLContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Stop> Stops{ get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Journey> Journeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer(@"Data Source=localhost;Initial Catalog=test2;Integrated Security=True");
    }
   
}
