using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDemo.Models
{
    public class ParkingContext : DbContext
    {
        public ParkingContext(DbContextOptions options): base(options) { }

        public DbSet<Parking> Parkings { get; set; }
        public DbSet<ParkingPlace> ParkingPlaces { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<Parking>()
                .HasKey(p => p.Name);

            builder.Entity<Parking>()
                .HasMany(p => p.Places)
                .WithOne(p => p.Parking)
                .HasForeignKey(p => p.ParkingName)
                .IsRequired();

            builder.Entity<ParkingPlace>()
                .HasKey(p => new { p.ParkingName, p.Number });

            builder.Entity <Command>()
                .HasKey(c => c.Id);
        }
    }
}
