using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C00756SF01P.CyberMan.Edge.WebAPI
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
          : base(options)
        {
        }

        public DbSet<Status> Statuses{ get; set; }
    }
}
