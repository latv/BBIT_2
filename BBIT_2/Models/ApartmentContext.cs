

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Models
{

    public class ApartmentContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartments>()
                .HasOne<Homes>()
                .WithMany()
                .HasForeignKey(p => p.HomeId);               
        }

        public ApartmentContext(DbContextOptions<ApartmentContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Apartments> Apartments { get; set; }
    }

}
