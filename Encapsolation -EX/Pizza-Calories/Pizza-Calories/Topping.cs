using System;
using System.Collections.Generic;

namespace Pizza_Calories
{
    public class Topping
    { 
        private Dictionary<string, double> toppings = new Dictionary<string, double>()
        {
            ["meat"] = 1.2,
            ["veggies"] = 0.8,
            ["cheese"] = 1.1,
            ["sauce"] = 0.9,          
        };

        private const int maxWeight = 50;

        private string name;
        private int weight;

        public Topping(string nameToping, int weightToping)
        {
            NameToping = nameToping;
            WeightToping = weightToping;
        }

        public string NameToping 
        { 
            get => name;
            set 
            {
                if (!toppings.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                name = value;
            }
            
        }
        public int WeightToping 
        {
            get => weight;
            set
            {
                if (value > maxWeight)
                {
                    throw new ArgumentException($"{NameToping} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public override string ToString()
        {
            //(1 * 1.2) * 30 * 2
            double toppingCalories = toppings[NameToping];

            double calories = (1 * toppingCalories) * weight * 2;

            return $"{calories:f2}";
        }
    }
}
