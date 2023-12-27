﻿namespace SimpleSnake.GameObjects
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

        public bool IsColideWith(Point point)
        {
            return point.X == 0 ||
                   point.Y == 0 ||
                   point.X == X - 1 ||
                   point.Y == Y;
        }
    }
}
