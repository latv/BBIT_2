

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Models
{

    public class ApartmentContext : DbContext
    {


        public ApartmentContext(DbContextOptions<ApartmentContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Apartments> Apartments { get; set; }
    }

}
