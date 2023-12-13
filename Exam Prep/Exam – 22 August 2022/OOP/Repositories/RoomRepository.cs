using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;



namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly ICollection<IRoom> rooms;

        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }
        public void AddNew(IRoom model) => rooms.Add(model);

        public IRoom Select(string criteria)
        {
            var room = rooms.FirstOrDefault(r => r.GetType().Name == criteria);

            if (room == null)
            {
                return null;
            }
            return room;
        }

        public IReadOnlyCollection<IRoom> All() => rooms.ToList().AsReadOnly();

    }
}
