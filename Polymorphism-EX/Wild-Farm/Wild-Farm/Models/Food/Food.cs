using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Models.Food
{
    public class Food : IFood
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
