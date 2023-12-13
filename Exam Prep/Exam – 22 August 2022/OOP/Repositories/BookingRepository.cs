using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly ICollection<IBooking> booking;

        public BookingRepository()
        {
            booking = new List<IBooking>();
        }
        public void AddNew(IBooking model) => booking.Add(model);

        public IBooking Select(string criteria)
        {
            var currBooking = booking.FirstOrDefault(r => r.GetType().Name == criteria);

            if (currBooking == null)
            {
                return null;
            }
            return currBooking;
        }

        public IReadOnlyCollection<IBooking> All() => booking.ToList().AsReadOnly();
    }
}
