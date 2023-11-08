using Animals.AbsClass;
using Animals.Animals.Cat;
using Animals.Animals.Dog;
using Animals.Animals.Frog;
using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            List<Animal> animals = new List<Animal>();

            string animalType;

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string[] animalInfo = Console.ReadLine().Split(" ",
                        StringSplitOptions.RemoveEmptyEntries);

                    Animal animal = null;

                    switch (animalType)
                    {
                        case "Dog": animal = new Dog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]); break;
                        case "Cat": animal = new Cat(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]); break;
                        case "Frog": animal = new Frog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]); break;
                        case "Kitten": animal = new Kitten(animalInfo[0], int.Parse(animalInfo[1])); ; break;
                        case "Tomcat": animal = new Tomcat(animalInfo[0], int.Parse(animalInfo[1])); break;

                    }

                    animals.Add(animal);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}  