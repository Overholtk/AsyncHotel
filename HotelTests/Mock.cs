﻿using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using AsyncHotel.Data;
using AsyncHotel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HotelTests
{
    class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        private readonly AsyncInnDBContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new AsyncInnDBContext(
                new DbContextOptionsBuilder<AsyncInnDBContext>()
                .UseSqlite(_connection)
                .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

        protected async Task<Amenity> CreateAndSaveTestAmenity()
        {
            var amenity = new Amenity { Name = "TestAmenity" };
            _db.Amenities.Add(amenity);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, amenity.ID);
            return amenity;

        }

        protected async Task<Room> CreateAndSaveTestRoom(){
            var room = new Room{ Nickname = "Test", Layout = 2 };
            _db.Rooms.Add(room);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, room.ID);
            return room;

        }
    }
}