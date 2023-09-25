using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace Pizza_Calories
{
    public class Dough
    {
        private const double minDoughGrams = 1;
        private const double maxDoughGrams = 200;
        private const double caloriesPerGram = 2;

        private const string exMessInvalidDough = "Invalid type of dough.";
        private const string exMessageDoughWeight = "Dough weight should be in the range [{0}..{1}].";

        private readonly Dictionary<string, double> flourAndTehchnique = new Dictionary<string, double>()
        {
            ["white"] = 1.5,
            ["wholegrain"] = 1.0, 
            ["crispy"] = 0.9,
            ["chewy"] = 1.1,
            ["homemade"] = 1.0,
        };
      

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
            get => flourType;
            private set
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
           private set
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
           private set
            {
                if (value< minDoughGrams || value > maxDoughGrams)
                {
                    throw new ArgumentException(string.Format(exMessageDoughWeight, minDoughGrams, maxDoughGrams));
                }
                this.weightDough = value;
            }            
        }

        public double CaloriesPerGram
             => caloriesPerGram
             * weightDough
             * flourAndTehchnique[FlourType.ToLower()]
             * flourAndTehchnique[BakingTechnique.ToLower()];

    }
}
