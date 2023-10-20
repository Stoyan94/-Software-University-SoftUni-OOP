using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Factories.Interfaces
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string[] animalTokes);
    }
}
