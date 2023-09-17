using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;

List<Person> people = new List<Person>();
List<Product> products = new List<Product>();

string[] nameMoneyPairs = Console.ReadLine().Split(";",
    StringSplitOptions.RemoveEmptyEntries);

try
{
    foreach (string pair in nameMoneyPairs)
    {
        string[] nameMoney = pair.Split("=");

        Person person = new Person(nameMoney[0], decimal.Parse(nameMoney[1]));

        people.Add(person);
    }


    string[] productCostPairs = Console.ReadLine().Split(";",
        StringSplitOptions.RemoveEmptyEntries);

    foreach (string pair in productCostPairs)
    {
        string[] productCost = pair.Split("=");

        Product product = new Product(productCost[0], decimal.Parse(productCost[1]));

        products.Add(product);
    }
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);

    return;
}


string input;

while ((input = Console.ReadLine())!="END")
{
    string[] personProduct = input.Split(" ",
        StringSplitOptions.RemoveEmptyEntries);

    string personName = personProduct[0];
    string productName = personProduct[1];

    Person person = people.FirstOrDefault(p=> p.Name == personName);

    Product product = products.FirstOrDefault(p=> p.Name == productName);

    if (product != null && product is not null) 
    {
        Console.WriteLine(person.AddProduct(product));
    }
}

foreach (var person in people)
{
    Console.WriteLine(person);
}
