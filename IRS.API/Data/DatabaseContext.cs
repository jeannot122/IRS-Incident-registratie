using IRS.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IRS.API.Data
{
    public class DatabaseContext : DbContext
    {
        private const string ConnectionString = @"server=192.168.178.14;user id=Jeannot;password=Jeannot150796;persistsecurityinfo=True;database=irsdb;port=3306";

        public virtual DbSet<AccountModel> Accounts { get; set; }
        public virtual DbSet<IncidentModel> Incidents { get; set; }
        public virtual DbSet<LocationModel> Locations { get; set; }
        public virtual DbSet<CustomerModel> Customers { get; set; }

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConnectionString);
        }
    }
}
