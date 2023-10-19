namespace Vehicles.Models.Interfaces
{
    internal interface IVehicel
    {
        public double FuelQuantity { get; }
        public double FuelConsumption  { get; }

        string Drive(double distance);
        void Refuel(double amout);
    }
}
