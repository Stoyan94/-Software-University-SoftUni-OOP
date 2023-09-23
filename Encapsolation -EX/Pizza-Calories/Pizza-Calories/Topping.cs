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

        private string type;
        private int weightTopping;
     
        public Topping(string nameToping, int weightToping)
        {
            NameToping = nameToping;
            WeightToping = weightToping;
        }

        public string NameToping 
        { 
            get => type;
            set 
            {
                if (!toppings.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
            
        }
        public int WeightToping 
        {
            get => weightTopping;
            set
            {
                if (value > maxWeight)
                {
                    throw new ArgumentException($"{NameToping} weight should be in the range [1..50].");
                }
                weightTopping = value;
            }
        }

        public double ToppingCal()
        {
            //(1 * 1.2) * 30 * 2
            double toppingCalories = toppings[NameToping];

            double calories = (1 * toppingCalories) * weightTopping * 2;

            return calories;
        }
    }
}
