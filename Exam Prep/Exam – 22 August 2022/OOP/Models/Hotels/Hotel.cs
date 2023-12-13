using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
        }

        public string FullName
        {
            get => fullName; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }

                fullName = value;
            }
        }


        public int Category
        {
            get => category; 
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }
                category = value;
            }
        }

        public double Turnover => throw new NotImplementedException();

        public IRepository<IRoom> Rooms => throw new NotImplementedException();

        public IRepository<IBooking> Bookings => throw new NotImplementedException();
    }
}
