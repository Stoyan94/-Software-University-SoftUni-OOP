using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        public Cocktail(string name, string size, double price)
        {
            this.Name = name;
            this.Size = size;
            this.Price = price;
        }
        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                name = value;
            }
        }


        public string Size { get => size; private set => size = value; }

        public double Price
        {
            get => price; 
            private set
            {
                if (Size == "Middle")
                {
                    price = 1 / 3 * value;
                }
                else if (Size == "Middle")
                {
                    price = 2 / 3 * value;
                }
                else
                {               
                    price = value;
                }
            }
        }


        public override string ToString()
        {
            return $"{Name} ({size}) - {price:f2} lv";
        }
    }
}
