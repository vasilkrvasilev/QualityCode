using System;

// Create private fields width and height and protected properties Width and Height to verify their values
// Use only one protected constructor taking two parameters (use properties Width and Height)
// Create two abstract methods CalcPerimeter() and CalcSurface()
namespace Abstraction
{
    abstract class Figure
    {
        private double width;
        private double height;

        public  double Width
        {
            get { return this.width; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input! You should enter positive number for width.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input! You should enter positive number for height.");
                }

                this.height = value;
            }
        }

        protected Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();
    }
}