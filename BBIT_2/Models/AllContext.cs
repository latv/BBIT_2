

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT_2.Models
{

    public class AllContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartments>()
                .HasOne<Homes>()
                .WithMany()
                .HasForeignKey(p => p.HomeId);
            modelBuilder.Entity<Resident>()
                .HasOne<Apartments>()
                .WithMany()
                .HasForeignKey(p => p.ApartmentId);
        }

        public AllContext(DbContextOptions<AllContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Apartments> Apartments { get; set; }
        public DbSet<Homes> Homes { get; set; }
        public DbSet<Resident> Residents { get; set; }
    }

}
