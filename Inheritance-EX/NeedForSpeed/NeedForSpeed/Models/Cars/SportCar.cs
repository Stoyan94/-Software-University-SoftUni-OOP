using NeedForSpeed.Models;

namespace NeedForSpeed.Models.Cars
{
    public class SportCar : Vehicle
    {
        private const double DefaulSportCarFuelConsumption = 10;
        public SportCar(double fuel, int horsePower)
            : base(fuel, horsePower)
        { }

        public override double FuelConsumption => DefaulSportCarFuelConsumption;
    }
}
