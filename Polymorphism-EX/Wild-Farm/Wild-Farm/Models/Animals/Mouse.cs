using System;
using System.Collections.Generic;
using Wild_Farm.Models.Food;

namespace Wild_Farm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double MouseWeightMultiplier = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightMultiplier => MouseWeightMultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes
            => new HashSet<Type>() {typeof(Vegetable), typeof(Fruit)};


        public override string ProduceSound() => "Squeak";
    }
}
