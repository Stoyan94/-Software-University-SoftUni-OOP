namespace NeedForSpeed.Models
{
    public abstract class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        private double fuel;
        private int horsePower;

        public Vehicle(double fuel, int horsePower)
        {
            Fuel = fuel;
            HorsePower = horsePower;
        }

        public virtual double FuelConsumption
            => DefaultFuelConsumption;
        public double Fuel
        {
            get { return fuel; }
            private set { fuel = value; }
        }
        public int HorsePower
        {
            get { return horsePower; }
            private set { horsePower = value; }
        }

        public virtual void Drive(double kilometers)
            => Fuel -= kilometers * FuelConsumption;

        public override string ToString()
        {
            return $"{Fuel}";
        }

    }
}
