namespace SimpleSnake.GameObjects
{
    internal class Wall : GameObject
    {
        private const char WallSymbol = '\u25A0';
        public Wall(char drawSymbol) 
            : base(drawSymbol)
        {
            
        }

        public Wall(char drawSymbol, int x, int y) 
            : base(drawSymbol, x, y)
        {
            DrawHorizontalLine(0);
        }

        private void DrawHorizontalLine(int colum)
        {
            for (int row = 0; row < X; row++)
            {
                GameObject drawPoint = new GameObject(drawSymbol, X, colum);
            }
        }
    }
}
