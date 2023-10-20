using System;
using System.Collections.Generic;
using Wild_Farm.Models.Food;

namespace Wild_Farm.Models.Animals
{
    public class Hen : Bird
    {
        private const double HenWeightMultiplier = 0.35;
        public Hen(string name, double weight, int wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightMultiplier => HenWeightMultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes
            => new HashSet<Type> { 
                  typeof(Vegetable)
                , typeof(Fruit)
                , typeof(Meat)
                , typeof(Seeds) };

        public override string ProduceSound() => "Cluck";
    }
}
