namespace NeedForSpeed
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters)
            : base(name, price)
        {
            Mililiters = milliliters;
        }

        public double Mililiters { get; private set; }
    }
}
