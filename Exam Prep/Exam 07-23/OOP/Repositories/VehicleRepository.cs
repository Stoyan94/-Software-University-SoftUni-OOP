using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private readonly ICollection<IVehicle> vehicleRepository;

        private VehicleRepository()
        {
            vehicleRepository = new List<IVehicle>();
        }
        public void AddModel(IVehicle model)
        {
            vehicleRepository.Add(model);
        }

        public IVehicle FindById(string identifier)
        {
            var curVehicle = vehicleRepository.FirstOrDefault(v => v.LicensePlateNumber == identifier);

            if (curVehicle is null)
            {
                return null;
            }

            return curVehicle;
        }

        public IReadOnlyCollection<IVehicle> GetAll()
             => (IReadOnlyCollection<IVehicle>) vehicleRepository;

        public bool RemoveById(string identifier)
        {
            var curVehicle = vehicleRepository.FirstOrDefault(v => v.LicensePlateNumber == identifier);

            if (curVehicle is null)
            {
                return false;
            }
            return true;
        }
    }
}
