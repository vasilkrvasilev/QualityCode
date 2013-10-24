using System;

// Inherit class Figure and override methods CalcPerimeter() and CalcSurface()
// Create property Radius
// Constructor takes one parameter radius, which inherit the base one with parameters radius and radius
// Assign to property Radius the value of property Width
namespace Abstraction
{
    class Circle : Figure
    {
        public double Radius { get; protected set;  }

        public Circle(double radius)
            : base(radius, radius)
        {
            this.Radius = this.Width;
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}