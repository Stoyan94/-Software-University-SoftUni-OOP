using System;

namespace Pizza_Calories
{
    public class Pizza
    {
        private const int maxSymbolsName = 15;
        private const int minSymbolsName = 1;
        private const string exMessageNamePizza = "Pizza name should be between {0} and {1} symbols";

        private string namePizza;
        private Dough dough;
        private Topping toppings;

        public Pizza(string namePizza, Dough dough, Topping topping)
        {
            NamePizza = namePizza;
            Dough = dough;
            Topping = topping;
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
            }
        }

        public Dough Dough 
        { 
            get=> dough; 
            set=> dough =value; 
        }

        public Topping Topping { get; set; }
    }
}
