using System;
using System.Collections.Generic;
using System.Data;

namespace Pizza_Calories
{
    public class Topping
    {
        private const int minWeight = 1;
        private const int maxWeight = 50;
        private const int calloriesPerGram = 2;

        private const string exMessageNameTopping = "Cannot place {0} on top of your pizza.";
        private const string exMessWeightTooping = "{0} weight should be in the range [{1}..{2}].";

        private readonly Dictionary<string, double> toppings = new Dictionary<string, double>()
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
            this.NameToping = nameToping;
            this.WeightToping = weightToping;
        }

        public string NameToping 
        {
            get => type;
            private set 
            {
                if (!toppings.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(string.Format(exMessageNameTopping,value));
                }

                this.type = value;
            }
            
        }
        public double WeightToping 
        {
            get => weightTopping;
           private set
            {
                if (value < minWeight || value > maxWeight)
                {
                     throw new ArgumentException(string.Format(exMessWeightTooping, NameToping,minWeight, maxWeight));
                }
                this.weightTopping = value;
            }
        }

        public double ToppingCal
             => calloriesPerGram
             * weightTopping
             * toppings[type.ToLower()];
    }
}
