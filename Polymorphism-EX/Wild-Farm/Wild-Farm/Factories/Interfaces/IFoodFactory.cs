using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Factories.Interfaces
{
    public interface IFoodFactory
    {
        IFood CreateFood(string type, int quantity);
    }
}
