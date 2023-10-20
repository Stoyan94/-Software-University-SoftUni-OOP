using System;
using System.Collections.Generic;
using Wild_Farm.Models.Food;

namespace Wild_Farm.Models.Animals
{   
    public class Dog : Mammal
    {
        private const double DogWeightMultiplier = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightMultiplier => DogWeightMultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes 
            => new HashSet<Type>() {typeof(Meat)};

        public override string ProduceSound() => "Woof!";

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
