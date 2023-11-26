using EDriveRent.Models;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<Vehicle>
    {
        private readonly ICollection<Vehicle> vehicleRepository;

        private VehicleRepository()
        {
            vehicleRepository = new List<Vehicle>();
        }
        public void AddModel(Vehicle model)
        {
            vehicleRepository.Add(model);
        }

        public Vehicle FindById(string identifier)
        {
            var currUser = vehicleRepository.FirstOrDefault(u => u.LicensePlateNumber == identifier);

            if (currUser is null)
            {
                return null;
            }

            return currUser;
        }

        public IReadOnlyCollection<Vehicle> GetAll()
             => (IReadOnlyCollection<Vehicle>) vehicleRepository;

        public bool RemoveById(string identifier)
        {
            var currUser = vehicleRepository.FirstOrDefault(u => u.LicensePlateNumber == identifier);

            if (currUser is null)
            {
                return false;
            }
            return true;
        }
    }
}
