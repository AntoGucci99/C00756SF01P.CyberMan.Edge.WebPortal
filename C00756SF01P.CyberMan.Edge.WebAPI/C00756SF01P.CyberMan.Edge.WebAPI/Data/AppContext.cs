using Microsoft.EntityFrameworkCore;
namespace C00756SF01P.CyberMan.Edge.WebAPI
{
    public class AppContext : DbContext
    {
        public AppContext()
        {
        }

        public AppContext(DbContextOptions<AppContext> options)
          : base(options)
        {

            Database.EnsureCreated();
        }
        //public AppContext CreateDbContext(string[] args)
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
        //    optionsBuilder.UseSqlite("Data Source=bmu.db");

        //    return new AppContext(optionsBuilder.Options);
        //}

        public DbSet<Status> Statuses{ get; set; }
    }
}
