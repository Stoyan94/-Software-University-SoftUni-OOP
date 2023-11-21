using System;
using System.Collections.Generic;
using Wild_Farm.Core.Interfaces;
using Wild_Farm.Factories.Interfaces;
using Wild_Farm.IO.Interfaces;
using Wild_Farm.Models.Interfaces;


namespace WildFarm.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;

    private readonly IAnimalFactory animalFactory;
    private readonly IFoodFactory foodFactory;

    private readonly ICollection<IAnimal> animals;

    public Engine(
        IReader reader,
        IWriter writer,
        IAnimalFactory animalFactory,
        IFoodFactory foodFactory)
    {
        this.reader = reader;
        this.writer = writer;

        this.animalFactory = animalFactory;
        this.foodFactory = foodFactory;

        animals = new List<IAnimal>();
    }

    public void Run()
    {
        string command;
        while ((command = reader.ReadLine()) != "End")
        {
            IAnimal animal = null;

                
            animal = animalFactory.CreateAnimal(command);
                
            IFood food = CreateFood();
                
            writer.WriteLine(animal.ProduceSound());

            try
            {
                animal.Eat(food);
            }
            catch (ArgumentException ex)
            {
                writer.WriteLine(ex.Message);
            }
           

            animals.Add(animal);
        }

        foreach (IAnimal animal in animals)
        {
            writer.WriteLine(animal);
        }
    }

   

    private IFood CreateFood()
    {
        string[] foodTokens = reader.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string foodType = foodTokens[0];
        int foodQuantity = int.Parse(foodTokens[1]);

        IFood food = foodFactory.CreateFood(foodType, foodQuantity);

        return food;
    }
}