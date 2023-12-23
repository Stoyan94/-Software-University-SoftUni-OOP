namespace SimpleSnake
{
    using System;
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            Wall borders = new Wall(60,20);
            borders.Draw();
            //Snake snake = new Snake();
            //Engine engine = new Engine();

            //engine.Run();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
