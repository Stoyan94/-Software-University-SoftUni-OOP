using System;
using System.Collections.Generic;

namespace Pizza_Calories
{
    public class Topping
    {
        private const int minWeight = 1;
        private const int maxWeight = 50;

        private const string exMessageNameTopping = "Cannot place {0} on top of your pizza.";
        private const string exMessWeightTooping = "{0} weight should be in the range[{1}..{2}].";

        private Dictionary<string, double> toppings = new Dictionary<string, double>()
        {
            ["meat"] = 1.2,
            ["veggies"] = 0.8,
            ["cheese"] = 1.1,
            ["sauce"] = 0.9,          
        };    

        private string type;
        private double weightTopping;
     
        public Topping(string nameToping, double weightToping)
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
                    throw new ArgumentException(string.Format(exMessageNameTopping,value));
                }

                type = value;
            }
            
        }
        public double WeightToping 
        {
            get => weightTopping;
            set
            {
                if (value > maxWeight || value < 1)
                {
                     throw new ArgumentException(string.Format(exMessWeightTooping,NameToping ,minWeight, maxWeight));
                }
                weightTopping = value;
            }
        }

        public double ToppingCal()
        {
            //(1 * 1.2) * 30 * 2
            double toppingCalories = toppings[NameToping.ToLower()];

            double calories = (1 * toppingCalories) * weightTopping * 2;

            return calories;
        }
    }
}
