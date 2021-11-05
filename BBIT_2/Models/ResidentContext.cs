using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Models
{
    public class ResidentContext : DbContext
    {

        public ResidentContext(DbContextOptions<ResidentContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Resident> Residents { get; set; }
    }
}