using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char SnakeSymbol = '\u25CF';
        private const char EmptySymbol = ' ';

        private readonly Queue<GameObject> snakeElements;

        public Snake()
        {
            snakeElements = new Queue<GameObject>();
            GenerateSnakeElements();
        }

        public GameObject Head => snakeElements.Last();

        private void GenerateSnakeElements()
        {
           for (int y = 1; y <= 6; y++)
           {
                var obj = new GameObject(SnakeSymbol, 2, y);
                snakeElements.Enqueue(obj);   
                obj.Draw();
           }
        }

        internal void Move(GameObject newSnakeHead)
        {
            snakeElements.Enqueue(newSnakeHead);
            newSnakeHead.Draw();    

            GameObject tail = snakeElements.Dequeue();

            tail = new GameObject(EmptySymbol, tail.X, tail.Y);
            tail.Draw();
        }

        public bool IsCollidesWith(Point point)
        {
            return snakeElements.Any(se => se.X == point.X && se.Y == point.Y);
        }
    }
}
