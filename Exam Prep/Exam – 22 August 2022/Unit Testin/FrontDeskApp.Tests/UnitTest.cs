using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Linq;

namespace BookigApp.Tests
{
    public class Tests
    {
      
        [Test]
        public void HotelConstructorShouldInitializeCorrectly()
        {
            string expcName = "Goro";
            int excpCategory = 1;

            Hotel hote = new Hotel(expcName, excpCategory);

            Assert.AreEqual(hote.FullName, expcName);
            Assert.AreEqual(hote.Category, excpCategory);
            Assert.AreEqual(hote.Rooms.Count, 0);
            Assert.AreEqual(hote.Bookings.Count, 0);

        }

        [Test]

        public void HotelNameShouldThrowException()
        {          

            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel("  ", 3);
                Hotel hotel2 = new Hotel(null, 3);
            });
        }

        [Test]

        public void HotelCategoryShouldThrowExceptionWhenValueLesThen1AndMoreThan5()
        {
            Assert.Throws<ArgumentException>(() => 
            {
                Hotel hotel = new Hotel("Gro", 1);
                Hotel hotel2 = new Hotel("mro", 6);
            });
        }

        [Test]

        public void AddRoomMethodShouldWorkCorrectly()
        {
            Hotel hotel = new Hotel("Gro", 5);

            Room room = new Room(2,55.5);
            hotel.AddRoom(room);

            Assert.That(hotel.Rooms.Contains(room));
            Assert.AreEqual(room.PricePerNight, 55.5);
            Assert.AreEqual(room.BedCapacity, 2);          

        }

        [Test]

        public void BookRoomMethodShouldThrowExceptions()
        {
            Hotel hotel = new Hotel("Gro", 5);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(0, 2, 2, 100);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(1, -1, 2, 100);
            });
            
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(1, 1, 0, 100);
            });
        }
    }
}