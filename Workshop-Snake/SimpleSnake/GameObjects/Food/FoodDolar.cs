namespace SimpleSnake.GameObjects.Food
{
    internal class FoodDolar : Food
    {
        private const char Symbol = '$';
        private const int Points = 2;

        public FoodDolar()
            : base(Symbol, Points)
        {
        }
       
    }
}
