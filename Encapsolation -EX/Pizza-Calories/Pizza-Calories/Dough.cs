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
            ["White"] = 1.5,
            ["Wholegrain"] = 1.0,
            ["Chewy"] = 1.1,
            ["Crispy"] = 0.9,
            ["Homemade"] = 1.0,

        };

        private string flourType;
        private string bakingTechnique;
        private int weight;

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
                if (!flourAndTehchnique.ContainsKey(value))
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
                if (!flourAndTehchnique.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough");
                }

                this.bakingTechnique = value;
            }
            
        }

        public int Weight
        {
            get => weight;
            set
            {
                this.weight = value;
            }
        }

        public override string ToString()
        {
            int callories = (int)flourAndTehchnique[FlourType] + (int)flourAndTehchnique[BakingTechnique];


            return $"{callories}";
        }
    }
}
