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

            Assert.AreEqual(capacity, garage.Capacity);
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

        [Test]

        public void DriveVehicleShouldNotMoveIfBateryDraingeIsAbove100rHigherOfOurBattery()
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

            garage.DriveVehicle(vehicle.LicensePlateNumber, 120, false);

            garage.DriveVehicle(vehicle2.LicensePlateNumber, 50, false);
            garage.DriveVehicle(vehicle2.LicensePlateNumber, 60, false);

            garage.DriveVehicle(vehicle3.LicensePlateNumber, 50, true);
            garage.DriveVehicle(vehicle3.LicensePlateNumber, 10, true);

           

            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.AreEqual(50, vehicle2.BatteryLevel);
            Assert.AreEqual(50, vehicle3.BatteryLevel);
        
        }

        [Test]
        public void RepairVehicleShouldRepairAllDamageVehicles()
        {
            Garage garage = new Garage(5);

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


            garage.DriveVehicle(vehicle.LicensePlateNumber, 30, true);
            garage.DriveVehicle(vehicle2.LicensePlateNumber, 50, true);
            garage.DriveVehicle(vehicle3.LicensePlateNumber, 50, true);

            var resultRepair = garage.RepairVehicles();
            var allRepairVehicles = garage.Vehicles.Any(x => !x.IsDamaged);

            Assert.AreEqual($"Vehicles repaired: 3", resultRepair);
            Assert.IsTrue(allRepairVehicles);
        }
    }
}
