using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using System.Linq;
using System.Text;


namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IUser> users;
        private readonly IRepository<IVehicle> vehicles;
        private readonly IRepository<IRoute> routesRepo;

        public Controller()
        {
            this.users = new UserRepository();
            this.vehicles = new VehicleRepository();
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

            route = this.routesRepo.GetAll().FirstOrDefault(r =>
            r.StartPoint == startPoint &&
            r.EndPoint == endPoint &&
            r.Length < length);

            if (route is not null)
            {
                return $"{startPoint}/{endPoint} shorter route is already added in our platform.";
            }

            route = this.routesRepo.GetAll().FirstOrDefault(r =>
            r.StartPoint == startPoint &&
            r.EndPoint == endPoint &&
            r.Length > length);

            if (route is not null)
            {
                route.LockRoute();
            }

            var countRoutes = routesRepo.GetAll().Count;

            var newRoute = new Route(startPoint, endPoint, length, countRoutes +1);

            this.routesRepo.AddModel(newRoute);

            return $"{startPoint}/{endPoint} - {length} km is unlocked in our platform.";
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            var user = users.FindById(drivingLicenseNumber);
            var route = routesRepo.FindById(routeId);
            var vehicle = vehicles.FindById(licensePlateNumber);

            if (user.IsBlocked)
            {
                return $"User {drivingLicenseNumber} is blocked in the platform! Trip is not allowed.";
            }
            else if (vehicle.IsDamaged)
            {
                return $"Vehicle {licensePlateNumber} is damaged! Trip is not allowed.";
            }
            else if (route.IsLocked)
            {
                return $"Route {routeId} is locked! Trip is not allowed.";
            }

            vehicle.Drive(route.Length);

            if (isAccidentHappened)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();

            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            var user = this.users.FindById(drivingLicenseNumber);

            if (user != null)
            {
                return $"{drivingLicenseNumber} is already registered in our platform.";
            }    

            this.users.AddModel(new User(firstName, lastName , drivingLicenseNumber));

            return $"{firstName} {lastName} is registered successfully with DLN-{drivingLicenseNumber}";
        }

        public string RepairVehicles(int count)
        {
            var damageVehicle = this.vehicles.GetAll()
                .Where(v => v.IsDamaged)
                .OrderBy(b => b.Brand)
                .ThenBy(m => m.Model)
                .Take(count)
                .ToList();

            foreach (var vehicle in damageVehicle)
            {
                vehicle.Recharge();
                vehicle.ChangeStatus();
            }

            return $"{damageVehicle.Count} vehicles are successfully repaired!";
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType != "PassengerCar" && vehicleType !="CargoVan")
            {
                return $"{vehicleType} is not accessible in our platform.";
            }

            var vehicle = vehicles.FindById(licensePlateNumber);

            if (vehicle != null)
            {
                return $"{licensePlateNumber} belongs to another vehicle.";
            }

            vehicle = null;

            if (vehicleType == "CargoVan")
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            else
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }
           
            vehicles.AddModel(vehicle);

            return $"{brand} {model} is uploaded successfully with LPN-{licensePlateNumber}";
        }

        public string UsersReport()
        {
            StringBuilder output = new StringBuilder();

            var usersReport = users.GetAll().
                OrderByDescending(r => r.Rating).
                ThenBy(l => l.LastName).
                ThenBy(f => f.FirstName).ToList();

            output.AppendLine("*** E-Drive-Rent ***");

            foreach (var user in usersReport)
            {
                output.AppendLine(user.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
