using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Linq;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHotel> hotelRepository;

        public Controller()
        {
            hotelRepository = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            if (hotelRepository.All().Any(h => h.FullName == hotelName))
            {
                return $"Hotel {hotelName} is already registered in our platform.";
            }

            var newHotel = new Hotel(hotelName, category);

            hotelRepository.AddNew(newHotel);

            return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            var currHotel = hotelRepository.Select(hotelName);

            if (currHotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }
           
            IRoom room = currHotel.Rooms.Select(roomTypeName);

            if (room != null)
            {
                return $"Room type is already created!";
            }

            if (roomTypeName != nameof(Apartment) && roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio))
            {
                throw new ArgumentException($"Incorrect room type!");
            }


            if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            else if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            
            currHotel.Rooms.AddNew(room);
            
            return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
        }
        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            var currHotel = hotelRepository.Select(hotelName);

            if (currHotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            if (roomTypeName != nameof(Apartment) && roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio))
            {
                throw new ArgumentException($"Incorrect room type!");
            }

            IRoom room = currHotel.Rooms.Select(roomTypeName);

            if (room == null)
            {
                return $"Room type is not created yet!";
            }
            else if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException("Price is already set!");
            }

            room.SetPrice(price);

            return $"Price of {roomTypeName} room type in {hotelName} hotel is set!";
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (hotelRepository.All().FirstOrDefault(c => c.Category == category) == null)
            {
                return $"{category} star hotel is not available in our platform.";
            }

            var bookHotel = hotelRepository.All().Where(c => c.Category == category).OrderBy(h => h.FullName);

            foreach (var hotel in bookHotel)
            {
                var room = hotel.Rooms.All()
                    .Where(p => p.PricePerNight > 0)
                    .OrderBy(b => b.BedCapacity)
                    .FirstOrDefault(r => r.BedCapacity >= adults + children);

                if (room != null)
                {
                    int bookingNumber = hotel.Bookings.All().Count + 1;

                    IBooking booking = new Booking(room, duration, adults, children, bookingNumber);

                    hotel.Bookings.AddNew(booking);

                    return $"Booking number {bookingNumber} for {hotel.FullName} hotel is successful!";
                }
            }        

            return "We cannot offer appropriate room for your request.";
        }

        public string HotelReport(string hotelName)
        {
            throw new NotImplementedException();
        }

    }
}
