using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;



namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private readonly ICollection<IHotel> hotel;

        public HotelRepository()
        {
            hotel = new List<IHotel>();
        }
        public void AddNew(IHotel model) => hotel.Add(model);

        public IHotel Select(string criteria)
        {
            var currHotel = hotel.FirstOrDefault(r => r.FullName == criteria);

            if (currHotel == null)
            {
                return null;
            }
            return currHotel;
        }

        public IReadOnlyCollection<IHotel> All() => hotel.ToList().AsReadOnly();
    }
}
