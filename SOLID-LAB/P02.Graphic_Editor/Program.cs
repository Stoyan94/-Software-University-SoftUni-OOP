using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape circle = new Circle();
            IShape rectangle = new Rectangle();
            IShape square = new Square();

            Console.WriteLine(circle.GetShape());
            Console.WriteLine(rectangle.GetShape());
            Console.WriteLine(square.GetShape());
        }
    }
}
