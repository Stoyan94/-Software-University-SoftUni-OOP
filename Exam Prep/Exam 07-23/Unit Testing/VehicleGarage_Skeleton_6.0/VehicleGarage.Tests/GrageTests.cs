using NUnit.Framework;
using System.Linq;

namespace VehicleGarage.Tests
{
    public class GrageTests
    {
        [TestCase(10)]
        [TestCase(1)]

        public void ConstructorShouldInitializeAllValues(int capacity)
        {
            Garage garage = new Garage(capacity);

            Assert.AreEqual(garage.Capacity, capacity);
            Assert.IsNotNull(garage.Vehicles);
        }

        [TestCase(5,"Nisan", "GTR", "BS5555BS")]

        public void AddVehicleShouldAddIfGarageHveEnoughtCapacity(int capacity, string modle,
            string brand, string licencePlate)
        {
            Garage garage = new(capacity);
            Vehicle vehicle = new(brand, modle, licencePlate);

           var result = garage.AddVehicle(vehicle);

            Assert.IsTrue(result);
            Assert.Contains(vehicle, garage.Vehicles);
        }

        [TestCase(5, "Nisan", "GTR", "BS5555BS")]

        public void AddVehicleShouldReturnFalseCarAllReadyExists(int capacity, string modle,
            string brand, string licencePlate)
        {
            Garage garage = new(capacity);
            Vehicle vehicle = new(brand, modle, licencePlate);

            garage.AddVehicle(vehicle);
            var result = garage.AddVehicle(vehicle);

            Assert.IsFalse(result);
        }

        [Test]
        public void AddVehicleShouldReturnFalseIfGarageFull()
        {
            Garage garage = new(3);
            Vehicle vehicle = new("Nisan", "GTR", "BS5555BS");
            Vehicle vehicle2 = new("Nisan", "Godzile", "BS5655BS");
            Vehicle vehicle3 = new("Nisan", "Aplha12", "BS5557BS");
            Vehicle vehicle4 = new("Nisan", "Aplha16", "BS5577BS");

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);

            var result = garage.AddVehicle(vehicle4);
            var containts = garage.Vehicles.Any(x => 
            x.Model == vehicle4.Model && 
            x.Brand == vehicle4.Brand && 
            x.LicensePlateNumber == vehicle4.LicensePlateNumber);

            Assert.IsFalse(result);
            Assert.IsFalse(containts);
        }

        [Test]
        public void ChargeVehicleShouldChargeAllVehicleUnderTheGivenValue()
        {
            Garage garage = new Garage(10);

            Vehicle vehicle = new Vehicle("Nisan", "GTR", "BS5555BS");
            Vehicle vehicle2 = new Vehicle("Nisan", "Godzile", "BS5655BS");
            Vehicle vehicle3 = new Vehicle("Nisan", "Aplha12", "BS5557BS");
            Vehicle vehicle4 = new Vehicle("Nisan", "Aplha16", "BS5577BS");
            Vehicle vehicle5 = new Vehicle("Nisan", "Aplha18", "BS5584BS");

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            garage.AddVehicle(vehicle4);
            garage.AddVehicle(vehicle5);

            garage.DriveVehicle(vehicle.LicensePlateNumber, 90, false);
            garage.DriveVehicle(vehicle2.LicensePlateNumber, 70, false);
            garage.DriveVehicle(vehicle3.LicensePlateNumber, 50, false);
            garage.DriveVehicle(vehicle4.LicensePlateNumber, 10, false);

            var chargeVehicle = garage.ChargeVehicles(50);

            Assert.AreEqual(chargeVehicle, 3);
            Assert.AreEqual(vehicle.BatteryLevel, 100);
            Assert.AreEqual(vehicle2.BatteryLevel, 100);
            Assert.AreEqual(vehicle3.BatteryLevel, 100);
            Assert.AreEqual(vehicle4.BatteryLevel, 90);
            Assert.AreEqual(vehicle5.BatteryLevel, 100);
        }
    }
}
