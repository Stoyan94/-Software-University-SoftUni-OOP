using Vehicles.Models.Interfaces;

namespace Vehicles.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicel Create(string type, double fuelQuantity, double fuelConsumption);
    }
}
