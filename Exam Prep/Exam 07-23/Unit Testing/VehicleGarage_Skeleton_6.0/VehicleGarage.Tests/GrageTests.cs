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
    }
}
