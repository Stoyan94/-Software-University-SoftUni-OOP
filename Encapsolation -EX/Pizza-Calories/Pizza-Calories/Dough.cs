using System.Collections.Generic;
using System.Linq;
using System;

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
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;
            set
            {
                if (!flourAndTehchnique.ContainsKey(flourType))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            set
            {

                bakingTechnique = value;
            }
        }

        public int Weight
        {
            get => weight;
            set
            {
                weight = value;
            }
        }
    }
}
