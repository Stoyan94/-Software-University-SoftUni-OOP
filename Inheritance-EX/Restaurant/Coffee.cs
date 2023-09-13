namespace NeedForSpeed
{
    public class Coffee : HotBeverage
    {
        private const decimal CoffeePrice = 3.50m;
        private const double CoffeeMilliliters = 50;
        public Coffee(string name, double caffeeine)
            : base(name, CoffeePrice, CoffeeMilliliters)
        {
            Caffeeine = caffeeine;
        }

        public double Caffeeine { get; private set; }
    }
}
