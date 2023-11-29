using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class VehicleTests
    {
       
        [TestCase("VW", "Golf", "CB7777XA")]
        [TestCase("Toyota", "Rav4", "CB7775VD")]
        public void ConstructorShouldInitilizeAllValues(string make, string model, string licencePlate)
        {
            Vehicle vehicle = new Vehicle(make, model, licencePlate);

            Assert.AreEqual(vehicle.Brand, make);
            Assert.AreEqual(vehicle.Model, model);
            Assert.AreEqual(vehicle.LicensePlateNumber, licencePlate);

            Assert.AreEqual(vehicle.IsDamaged, false);
            Assert.AreEqual(vehicle.BatteryLevel, 100);
        }
    }
}