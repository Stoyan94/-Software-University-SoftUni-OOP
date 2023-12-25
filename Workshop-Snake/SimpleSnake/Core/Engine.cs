using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Food;
using SimpleSnake.Utilities;
using System;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private const int SleepTime = 100;

        private Food[] foods;
        private Wall wall;
        private Snake snake;
        private Direction currentDirection;
        private Point[] pointsDirection;

        public Engine(Wall wall, Snake snake)
        {            
            CreateDirections();

            foods = new Food[3]
            {
                new FoodAasterisk(),
                new FoodDolar(),
                new FoodHash(),
            };

            this.wall = wall;
            this.snake = snake;
        }

        private void CreateDirections()
        {
            pointsDirection = new Point[]
            {
                new Point(1, 0),             
                new Point(-1, 0),            
                new Point(0, 1),             
                new Point(0, -1),
            };
           
        }
        public void Start()
        {           
            //PlaceFoodOnField();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    currentDirection = GetDirection();
                }

                UpdateSnake(pointsDirection[(int)currentDirection]);

                Thread.Sleep(SleepTime);
            }
        }

        private void UpdateSnake(Point directon)
        {
            GameObject currentSnakeHead = snake.Head;

            Point nextHeadPoint = GetNextPosition(directon, currentSnakeHead);

            GameObject snakeNewHead = new GameObject(currentSnakeHead.DrawSymbol, nextHeadPoint.X, nextHeadPoint.Y);

            snake.Move(snakeNewHead);
        }

        private Point GetNextPosition(Point directon, GameObject snakeHead)
        {
            return new Point(snakeHead.X + directon.X,
                             snakeHead.Y + directon.Y);
        }

        private Direction GetDirection()
        {
           return Platformnteraction.GetInput(currentDirection);
        }

        private void PlaceFoodOnField()
        {
            throw new NotImplementedException();
        }

        
    }
}