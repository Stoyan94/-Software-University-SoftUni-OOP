namespace SimpleSnake.GameObjects.Food
{
    internal class FoodAasterisk : Food
    {
        private const char Symbol = '*';
        private const int Points = 1;
        public FoodAasterisk()
            : base(Symbol, Points)
        {
        }

        
    }
}
