using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;


namespace Data.dbcontext
{
    public class fleetRouteProContext : DbContext
    {
        private readonly string _connectionString;

        public fleetRouteProContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DbSet<UsersModels> Users { get; set; }
        public DbSet<DrivesModels> Drivers { get; set; }
        public DbSet<VehiclesModels> Vehicles { get; set; }
        public DbSet<RouteModels> Routes { get; set; }
        public DbSet<ScheduleModels> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
        