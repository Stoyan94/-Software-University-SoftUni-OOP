using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IUser> usersRepo;
        private readonly IRepository<IVehicle> vehiclesRepo;
        private readonly IRepository<IRoute> routesRepo;

        public Controller()
        {
            this.usersRepo = new UserRepository();
            this.vehiclesRepo = new VehicleRepository();
            this.routesRepo = new RouteRepository();
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            var route = this.routesRepo.GetAll().FirstOrDefault(r =>
            r.StartPoint == startPoint && 
            r.EndPoint == endPoint &&
            r.Length == length);

            if (route is not null)
            {
                return $"{startPoint}/{endPoint} - {length} km is already added in our platform.";
            }

            if (route.Length < length)
            {
                return $"{startPoint}/{endPoint} shorter route is already added in our platform.";
            }         

            if (route.Length > length)
            {
                route.LockRoute();
            }

            var countRoutes = routesRepo.GetAll().Count + 1;

            var newRoute = new Route(startPoint, endPoint, length, countRoutes);

            this.routesRepo.AddModel(newRoute);

            return $"{startPoint}/{endPoint} - {length} km is unlocked in our platform.";
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            throw new NotImplementedException();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (this.usersRepo.FindById(drivingLicenseNumber) != null)
            {
                return $"{drivingLicenseNumber} is already registered in our platform.";
            }    

            this.usersRepo.AddModel(new User(firstName, lastName , drivingLicenseNumber));

            return $"{firstName} {lastName} is registered successfully with DLN-{drivingLicenseNumber}";
        }

        public string RepairVehicles(int count)
        {
            throw new NotImplementedException();
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType != "PassengerCar" && vehicleType !="CargoVan")
            {
                return $"{vehicleType} is not accessible in our platform.";
            }

            if (vehiclesRepo.FindById(licensePlateNumber) != null)
            {
                return $"{licensePlateNumber} belongs to another vehicle.";
            }

            IVehicle vehicle = null;

            if (vehicleType == "CargoVan")
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            else
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }
           

            return $"{brand} {model} is uploaded successfully with LPN-{licensePlateNumber}";
        }

        public string UsersReport()
        {
            throw new NotImplementedException();
        }
    }
}
