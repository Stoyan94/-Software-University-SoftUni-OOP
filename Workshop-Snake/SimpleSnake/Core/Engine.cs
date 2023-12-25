using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Food;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Food[] foods;
        private Wall wall;
        private Snake snake;
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

        public void Start()
        {

        }
    }
}