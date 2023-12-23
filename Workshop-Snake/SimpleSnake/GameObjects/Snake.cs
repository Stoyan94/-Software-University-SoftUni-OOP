using System;
using System.Collections.Generic;

namespace SimpleSnake.GameObjects
{
    internal class Snake
    {
        private const char SnakeSymbol = '\u25CF';
        private const char EmptySymbol = ' ';

        private readonly Queue<GameObject> snakeElements;

        public Snake()
        {
            snakeElements = new Queue<GameObject>();
            GenerateSnakeElements();
        }

        private void GenerateSnakeElements()
        {
           for (int y = 0; y <= 6; y++)
           {
                snakeElements.Enqueue(new GameObject(SnakeSymbol, 2, y));         
           }
        }
    }
}
