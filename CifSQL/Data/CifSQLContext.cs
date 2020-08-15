using CifSQL.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CifSQL.Data
{
    public class CifSQLContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Journey> Journeys { get; set; }

        public CifSQLContext(DbContextOptions<CifSQLContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //   => options.UseSqlServer(ConfigurationManager.ConnectionStrings["sql-server"].ConnectionString);
    }
   
}
