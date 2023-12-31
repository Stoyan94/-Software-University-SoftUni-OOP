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
        private Wall fieldBounderis;
        private Snake snake;
        private Direction currentDirection;
        private Point[] pointsDirection;
        private GameState state;
        private Random random;
        private Food foodReference;
        public Engine(Wall wall, Snake snake)
        {            
            CreateDirections();

            random = new Random();

            foods = new Food[3]
            {
                new FoodAasterisk(),
                new FoodDolar(),
                new FoodHash(),
            };

            this.fieldBounderis = wall;
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
            PlaceFoodOnField();

            while (state != GameState.Over)
            {
                if (Console.KeyAvailable)
                {
                    currentDirection = GetDirection();
                }

               state = UpdateSnakeReturntState(pointsDirection[(int)currentDirection]);

                Thread.Sleep(SleepTime);
            }
        }

        private GameState UpdateSnakeReturntState(Point directon)
        {
            GameObject currentSnakeHead = snake.Head;

            Point nextHeadPoint = GetNextPosition(directon, currentSnakeHead);

            if (fieldBounderis.IsCollideWith(nextHeadPoint))
            {
                return GameState.Over;
            }

            if (snake.IsCollidesWith(nextHeadPoint))
            {
                return GameState.Over;
            }


            if (foodReference.IsCollideWith(nextHeadPoint))
            {
                snake.Grow(directon, currentSnakeHead, foodReference.Points);
                PlaceFoodOnField();
            }

            GameObject snakeNewHead = new GameObject(currentSnakeHead.DrawSymbol, nextHeadPoint.X, nextHeadPoint.Y);

            snake.Move(snakeNewHead);

            return GameState.Running;
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
            int randomFoodIndex = random.Next(0, foods.Length - 1);
            foodReference = foods[randomFoodIndex];
       
            do
            {
                foodReference.X = random.Next(2, fieldBounderis.X - 2);
                foodReference.Y = random.Next(2, fieldBounderis.Y - 2);
            } while (snake.IsCollidesWith(foodReference));
            

            foodReference.Draw();
        }

        
    }

    internal enum GameState
    {
        Idle,
        Start,
        Running,
        Over
    }
}