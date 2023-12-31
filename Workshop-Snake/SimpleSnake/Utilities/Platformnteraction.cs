using SimpleSnake.Enums;
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

        internal static Direction GetInput(Direction currentDirection)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();   

            if (userInput.Key == ConsoleKey.LeftArrow && currentDirection != Direction.Right)
            {
                currentDirection = Direction.Left;                    
            }
            else if (userInput.Key == ConsoleKey.RightArrow && currentDirection != Direction.Left)
            {
                currentDirection = Direction.Right;
            }           
            else if (userInput.Key == ConsoleKey.UpArrow && currentDirection != Direction.Down)
            {
                currentDirection = Direction.Up;
            }
            else if (userInput.Key == ConsoleKey.DownArrow && currentDirection != Direction.Up)
            {
                currentDirection = Direction.Down;
            }

            return currentDirection;
        }
        public static void GameOver(Wall fieldBounderis)
        {
            int x = fieldBounderis.X + 1;
            int y = 3;

            Console.SetCursorPosition(x, y);
            Console.WriteLine("Wold you lie to continue? y/n");

            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.Y)
            {

            }
            else
            {

            }
        }
    }
}