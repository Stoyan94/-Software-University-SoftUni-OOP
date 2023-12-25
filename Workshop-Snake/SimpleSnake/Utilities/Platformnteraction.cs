using SimpleSnake.GameObjects;
using System;

namespace SimpleSnake.Utilities
{
    internal class Platformnteraction
    {
        public static void Draw(GameObject gameObject)
        {
            Console.SetCursorPosition(gameObject.X,gameObject.Y);
            Console.WriteLine(gameObject.DrawSymbol);
        }
    }
}