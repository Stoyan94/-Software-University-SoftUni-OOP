using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace Pizza_Calories
{
    public class Dough
    {
        private const int minDoughGrams = 1;
        private const int maxDoughGrams = 200;
        private const string exMessInvalidDough = "Invalid type of dough.";

        private string exMessageDoughWeight = "Dough weight should be in the range [{0}..{1}]";

        private Dictionary<string, double> flourAndTehchnique = new Dictionary<string, double>()
        {
            ["white"] = 1.5,
            ["wholegrain"] = 1.0, 
            ["chewy"] = 1.1,
            ["crispy"] = 0.9,
            ["homemade"] = 1.0,

        };

        private const int maxWeight = 200;

        private string flourType;
        private string bakingTechnique;
        private double weightDough;
     
        public Dough(string flourType, string bakingTechnique, double weight)            
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            set
            {
                if (!flourAndTehchnique.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(exMessInvalidDough);
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            set
            {
                if (!flourAndTehchnique.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(exMessInvalidDough);
                }

                this.bakingTechnique = value;
            }
            
        }

        public double Weight
        {
            get => weightDough;
            set
            {
                if (value > maxWeight)
                {
                    throw new ArgumentException(string.Format(exMessageDoughWeight, minDoughGrams, maxDoughGrams));
                }
                this.weightDough = value;
            }            
        }

        public double DoughCalories()
        {
            double flourCalories = flourAndTehchnique[FlourType.ToLower()];
            double bakingTechCalories = flourAndTehchnique[BakingTechnique.ToLower()];
            double callories = (2 * weightDough) * flourCalories * bakingTechCalories;


            return callories;
        }
    }
}
