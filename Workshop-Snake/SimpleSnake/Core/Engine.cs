using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Food;
using SimpleSnake.Utilities;
using System;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Food[] foods;
        private Wall wall;
        private Snake snake;
        private Direction currentDirection;
        private Point[] pointsDirection;

        public Engine(Wall wall, Snake snake)
        {
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
            pointsDirection[0] = new Point(1, 0);
            pointsDirection[1] = new Point(-1, 0);
            pointsDirection[2] = new Point(0, 1);
            pointsDirection[3] = new Point(0, -1);
        }
        public void Start()
        {
            CreateDirections();
            PlaceFoodOnField();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    currentDirection = GetDirection();
                }

                UpdateSnake(pointsDirection[(int)currentDirection]);
            }
        }

        private void UpdateSnake(Point directon)
        {
            GameObject currentSnakeHead = snake.Head;

            Point nextHeadPoint = GetNextPosition(directon, currentSnakeHead);
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