using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace Pizza_Calories
{
    public class Dough
    {
        //•	White - 1.5
        //•	Wholegrain - 1.0
        //•	Crispy - 0.9
        //•	Chewy - 1.1
        //•	Homemade - 1.0

        private Dictionary<string, double> flourAndTehchnique = new Dictionary<string, double>()
        {
            ["white"] = 1.5,
            ["wholegrain"] = 1.0, 
            ["chewy"] = 1.1,
            ["wrispy"] = 0.9,
            ["womemade"] = 1.0,

        };

        private const int maxWeight = 200;

        private string flourType;
        private string bakingTechnique;
        private int weightDough;
     
        public Dough(string flourType, string bakingTechnique, int weight)            
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
                    throw new ArgumentException("Invalid type of dough.");
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
                    throw new ArgumentException("Invalid type of dough");
                }

                this.bakingTechnique = value;
            }
            
        }

        public int Weight
        {
            get => weightDough;
            set
            {
                if (value > maxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [1..200].");
                }
                this.weightDough = value;
            }            
        }

        public override string ToString()
        {
            double flourCalories = flourAndTehchnique[FlourType.ToLower()];
            double bakingTechCalories = flourAndTehchnique[BakingTechnique.ToLower()];
            double callories = (2 * 100) * flourCalories * bakingTechCalories;


            return $"{callories:F2}";
        }
    }
}
