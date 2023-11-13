namespace Resturant.Models.Food
{
    public abstract class Dessert : Food
    {
        protected Dessert(string name, decimal price, double grams, double calories)
            : base(name, price, grams)
        {
            this.Calories = calories;
        }

        public double Calories { get; private set; }
    }
}
