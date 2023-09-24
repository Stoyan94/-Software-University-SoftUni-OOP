using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizza_Calories
{
    public class Pizza
    {
        private const double maxSymbolsName = 15;
        private const double minSymbolsName = 1;
        private const double minToppings = 0;
        private const double maxToppings = 10;

        private const string exMessageToppingsCount = "Number of toppings should be in range [{0}..{1}].";
        private const string exMessageNamePizza = "Pizza name should be between {0} and {1} symbols";

        private string namePizza;       
        private List<Topping> toppings;

        public Pizza(string namePizza, Dough dough)
        {
            this.NamePizza = namePizza;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string NamePizza
        {
            get => namePizza; 

            set 
            {
                if (string.IsNullOrWhiteSpace(value) 
                    || value.Length < minSymbolsName 
                    || value.Length > maxSymbolsName)
                {
                    throw new ArgumentException(string.Format(exMessageNamePizza, minSymbolsName,maxSymbolsName));
                }
                this.namePizza = value;
            }
        }

        public Dough Dough { get; private set; }

      
      
        public void AddTopping(Topping topping)
        {
            if (this.Count == 10)
            {
                throw new ArgumentException(string.Format(exMessageToppingsCount, minToppings, maxToppings));
            }
                
            this.toppings.Add(topping);
        }

        public int Count => toppings.Count;

        public double TotalCalories
          => Dough.CaloriesPerGram
          + toppings.Sum(x => x.ToppingCal);


        public override string ToString()
        {
            return $"{this.NamePizza} - {this.TotalCalories:f2} Calories.";
        }
    }
}
