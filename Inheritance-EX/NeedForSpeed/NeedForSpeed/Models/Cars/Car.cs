using NeedForSpeed.Models;

namespace NeedForSpeed.Models.Cars
{
    public class Car : Vehicle
    {
        private const double DefaulCarFuelConsumption = 3;
        public Car(double fuel, int horsePower)
            : base(fuel, horsePower)
        { }

        public override double FuelConsumption => DefaulCarFuelConsumption;
    }
}
