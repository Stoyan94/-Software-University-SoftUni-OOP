using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizza_Calories
{
    public class Pizza
    {
        private const int maxSymbolsName = 15;
        private const int minSymbolsName = 1;
        private const int minToppings = 0;
        private const int maxToppings = 10;

        private const string exMessageToppingsCount = "Number of toppings should be in range [{0}..{1}].";
        private const string exMessageNamePizza = "Pizza name should be between {0} and {1} symbols";

        private string namePizza;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string namePizza, Dough dough)
        {
            NamePizza = namePizza;
            Dough = dough;
            toppings = new List<Topping>();
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
                namePizza = value;
            }
        }

        public Dough Dough 
        { 
            get=> dough; 
            set=> dough =value; 
        }        

        public double TotalCalories 
        {
            get 
            {
                double sumCallories = dough.CaloriesPerGram;

                foreach (var topping in toppings)
                {
                    sumCallories += topping.ToppingCal;
                }
                
                return sumCallories;
            }
        }
        public void AddTopping(Topping topping)
        {
            if (this.Count == 10)
            {
                throw new ArgumentException(string.Format(exMessageToppingsCount, minToppings, maxToppings));
            }
                
            toppings.Add(topping);
        }

        public int Count => toppings.Count;

        public override string ToString()
        {
            return $"{namePizza} - {this.TotalCalories:f2} Calories.";
        }
    }
}
