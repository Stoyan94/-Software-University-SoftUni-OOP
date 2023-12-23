namespace SimpleSnake.GameObjects.Food
{
    internal class Food : GameObject
    {
        public Food(char drawSymbol)
            : base(drawSymbol)
        {
        }

        public Food(char drawSymbol, int x, int y)
            : base(drawSymbol, x, y)
        {
        }

        public int Points { get; set; }
    }
}
