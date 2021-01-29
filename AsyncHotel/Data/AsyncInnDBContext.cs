using AsyncHotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Data
{
    public class AsyncInnDBContext : DbContext
    {
        public AsyncInnDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, but does nothing
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotels>().HasData(
              new Hotels { ID = 1, Name = "The Glorious Accordian", StreetAddress = "246513 Street st", City = "Cityton", State = "New Statewise", Country = "Accordiantica", PhoneNumber = "5555555555"},
              new Hotels { ID = 2, Name = "The Unarmed Crystal", StreetAddress = "4864513 Street st", City = "Cityton", State = "New Statewise", Country = "Accordiantica", PhoneNumber = "5555555555" },
              new Hotels { ID = 3, Name = "Panoramic Goats Pub", StreetAddress = "2465489 Street st", City = "Cityton", State = "New Statewise", Country = "Accordiantica", PhoneNumber = "5555555555" }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { ID = 1, Nickname = "The Underdark", Layout = 0 },
                new Room { ID = 2, Nickname = "Dusty WereRat", Layout = 1 },
                new Room { ID = 3, Nickname = "Ancient Red Dragon", Layout = 3 }
            );

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { ID = 1, Name = "Heated Bath" },
                new Amenity { ID = 2, Name = "Oil Lamps" },
                new Amenity { ID = 3, Name = "Crawling Claw Control" }
            );
        }

        public DbSet<Hotels> Hotels { get; set; }

        public DbSet<Room> Rooms {get; set;}

        public DbSet<Amenity> Amenities { get; set; }
    }
}
