using System;
using System.Collections.Generic;
using Wild_Farm.Models.Food;

namespace Wild_Farm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightMultiplier => TigerWeightMultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes 
            => new HashSet<Type>() {typeof(Meat)};

        public override string ProduceSound() => "ROAR!!!";
    }
}
