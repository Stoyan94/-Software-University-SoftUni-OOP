using FrontDeskApp;
using NUnit.Framework;
using System;

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

   
    }
}