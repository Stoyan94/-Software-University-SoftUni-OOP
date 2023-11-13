using Resturant.Models.AbsClass;

namespace Resturant.Models.Food
{
    public abstract class Food : Product
    {
        protected Food(string name, decimal price, double grams)
            : base(name, price)
        {
            this.Grams = grams;
        }

        public double Grams { get; set; }
    }
}
