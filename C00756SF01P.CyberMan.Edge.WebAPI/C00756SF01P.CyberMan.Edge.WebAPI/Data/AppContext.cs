using C00756SF01P.CyberMan.Edge.WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace C00756SF01P.CyberMan.Edge.WebAPI
{
    public class AppContext : DbContext
    {

        public AppContext(DbContextOptions<AppContext> options)
          : base(options)
        {
            //DbContextOptionsBuilder otp = new DbContextOptionsBuilder();
            //otp.UseSqlServer(Configuration.GetConnectionString("Connection")));
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=tcp:smartfactory001.database.windows.net,1433;Initial Catalog=smarfactory-sql-001;Persist Security Info=False;User ID=admingio001;Password=antonucci001!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    base.OnConfiguring(optionsBuilder);
        //}
        //public AppContext CreateDbContext(string[] args)
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
        //    optionsBuilder.UseSqlite("Data Source=bmu.db");

        //    return new AppContext(optionsBuilder.Options);
        //}

        public DbSet<Status> Statuses{ get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Alert> Alerts { get; set; }
    }
}
