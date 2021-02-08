using AsyncHotel.Models.Interfaces.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HotelTests
{
    public class RoomTests : Mock
    {
        [Fact]
        public async Task Can_Add_Amenity_To_Room()
        {
            //Arrange
            var amenity = await CreateAndSaveTestAmenity();
            var room = await CreateAndSaveTestRoom();

            var repository = new RoomRepository(_db);

            //Act
            await repository.AddAmenityToRoom(room.ID, amenity.ID);

            //Assert
            var actualRoom = await repository.GetRoom(room.ID);

            Assert.Contains(actualRoom.Amenities, a => a.ID == amenity.ID);

            //Act
            await repository.RemoveAmenityFromRoom(room.ID, amenity.ID);

            //Assert
            actualRoom = await repository.GetRoom(room.ID);
            Assert.DoesNotContain(actualRoom.Amenities, a => a.ID == amenity.ID);
        }
    }
}
