using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Room8Project.Domain.Common;
using Room8Project.Domain.Entities;

namespace Room8Project.Persistence.Contexts
{
    public class Room8ProjectContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<TaxiDriver> TaxiDrivers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Account)
                .WithOne(ba => ba.Owner)
                .HasForeignKey<BankAccount>(ba => ba.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
