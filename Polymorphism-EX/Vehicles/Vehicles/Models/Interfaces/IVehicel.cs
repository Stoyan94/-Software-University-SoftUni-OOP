namespace Vehicles.Models.Interfaces
{
    public interface IVehicel
    {
        public double FuelQuantity { get; }
        public double FuelConsumption  { get; }

        string Drive(double distance);
        void Refuel(double amout);
    }
}
