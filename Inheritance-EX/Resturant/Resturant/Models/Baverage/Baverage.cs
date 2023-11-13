using Resturant.Models.AbsClass;

namespace Resturant.Models.Baverage
{
    public abstract class Baverage : Product
    {
        protected Baverage(string name, decimal price, double milliliters)
            : base(name, price)
        {
            this.Milliliters = milliliters;
        }

        public double Milliliters { get; private set; }
    }
}
