using System;
using System.Collections.Generic;
using Wild_Farm.Core.Interfaces;
using Wild_Farm.Factories;
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
        string input;

        IAnimal animal = null;
        IFood food = null;

        while ((input = reader.ReadLine()) != "End")
        {
            string[] cmdArgs = input.Split(" ",
                System.StringSplitOptions.RemoveEmptyEntries);

            animal = animalFactory.CreateAnimal(cmdArgs);

            string[] foodInfo = reader.ReadLine().Split(" ",
                StringSplitOptions.RemoveEmptyEntries);

            food = foodFactory.CreateFood(foodInfo[0], int.Parse(foodInfo[1]));

            writer.WriteLine(animal.ProduceSound());
            animals.Add(animal);

            try
            {
                animal.Eat(food);

            }
            catch (ArgumentException ex)
            {
                writer.WriteLine(ex.Message);
            }
        }

        foreach (var currAnimal in animals)
        {
            writer.WriteLine(currAnimal);
        }
    }
}