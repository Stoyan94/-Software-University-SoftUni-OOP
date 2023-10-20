using System;
using Wild_Farm.Factories.Interfaces;
using Wild_Farm.Models.Animals;
using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] animalTokes)
        {
            string type = animalTokes[0];
            string name = animalTokes[1];
            double weight = double.Parse(animalTokes[2]);

            switch (type)
            {
                case "Hen ":
                    return new Hen(name, weight, double.Parse(animalTokes[3]));
                case "Owl":
                    return new Owl(name, weight, double.Parse(animalTokes[3]));
                case "Mouse":
                    return new Mouse(name, weight, animalTokes[3]);
                case "Cat":
                    return new Cat(name, weight, animalTokes[3], animalTokes[4]);
                case "Dog":
                    return new Dog(name, weight, animalTokes[3]);
                case "Tiger":
                    return new Tiger(name, weight, animalTokes[3], animalTokes[4]);
                default:
                    throw new ArgumentException("Invalid food type!");
            }
        }
    }
}
