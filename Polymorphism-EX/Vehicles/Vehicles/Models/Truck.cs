namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double IncreaseConsum = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption, IncreaseConsum)
        {
        }

        public override void Refuel(double amout) => base.Refuel(amout * 0.95);
     
    }
}
