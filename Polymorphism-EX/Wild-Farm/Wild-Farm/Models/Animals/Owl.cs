﻿using System;
using System.Collections.Generic;
using Wild_Farm.Models.Food;

namespace Wild_Farm.Models.Animals
{
    public class Owl : Bird
    {
        private const double OwlWeightMultiplier = 0.25;
        public Owl(string name, double weight, int wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightMultiplier => OwlWeightMultiplier;

        protected override IReadOnlyCollection<Type> PrefferedFoodTypes
            => new HashSet<Type> { typeof(Meat) }; 

        public override string ProduceSound() => "Hoot Hoot";
    }
}
