using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Models.Animals
{
    public abstract class Bird : Animal, IBird
    {
        protected Bird(string name, double weight, int wingSize) 
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize {get; private set;}

        public override string ToString()
        {
            return base.ToString() + $"{WingSize} {Weight} {FoodEaten}]";
        }
    }
}
