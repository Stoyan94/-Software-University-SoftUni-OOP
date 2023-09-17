﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public string AddProduct(Product product)
        {
            if (Money < product.Cost)
            {
                return $"{Name} can't afford {product.Name}";
            }
            products.Add(product);

            Money -= product.Cost;

            return $"{Name} bought {product.Name}";
        }
        
        public override string ToString()
        {
            string productString = products.Any()
                ? string.Join(", ", products.Select(p => p.Name)) 
                : "Nothing bought";

            return $"{Name} - {productString}";
        }
    }  
}
