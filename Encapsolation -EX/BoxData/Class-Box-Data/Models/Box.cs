using System;

namespace ClassBoxData.Models
{
    public class Box
    {
        private const string PropZeroOrNegativeExMessage = "{0} cannot be zero or negative.";

        private double lenght;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            Lenght = lenght;
            Width = width;
            Height = height;
        }

        public double Lenght
        {
            get => lenght;
           private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropZeroOrNegativeExMessage, nameof(Lenght)));
                }

                lenght = value;
            }
        }
        public double Width
        {
            get => width;
          private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropZeroOrNegativeExMessage, nameof(Width)));
                }

                width = value;
            }
        }  
        public double Height
        {
            get => height;
           private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropZeroOrNegativeExMessage, nameof(Height)));
                }

                height = value;
            }
        }

        public double SurfaceArea()
           => 2 * Lenght * Width + LateralSurfaceArea();

        public double LateralSurfaceArea()
            => 2 * Lenght * Height + 2 * Width * Height;

        public double Volume()
            => Lenght * Width * Height;
    }
}
