using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Models
{
    public class HomeContext :DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Homes> Homes { get; set; }
    }
}
