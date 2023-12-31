using SimpleSnake.GameObjects;
using System;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X {  get; set; }

        public int Y { get; set; }


        public bool IsCollideWith(Point point)
        {
            return point.X == 0 ||
                   point.Y == 0 ||
                   point.X == X - 1 ||
                   point.Y == Y;
        }
        public static Point GetNextPoint(Point directon, GameObject point)
        {
            return new Point(
                   point.X + directon.X,
                   point.Y + directon.Y);
        }
    }
}
