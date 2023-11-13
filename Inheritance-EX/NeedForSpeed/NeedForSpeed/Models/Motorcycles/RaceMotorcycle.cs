namespace NeedForSpeed.Models.Motorcycles
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DefaulRaceMotorcycleFuelConsumption = 8;
        public RaceMotorcycle(double fuel, int horsePower)
            : base(fuel, horsePower)
        {
        }

        public override double FuelConsumption => DefaulRaceMotorcycleFuelConsumption;
    }
}
