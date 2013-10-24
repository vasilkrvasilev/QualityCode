using System;

// Extract method PrintFigure() with parameter Figure figure
// Use it in the Main() method
namespace Abstraction
{
    class FiguresExample
    {
        static void Main()
        {
            Circle circle = new Circle(5);
            PrintFigure(circle);

            Rectangle rectangle = new Rectangle(2, 3);
            PrintFigure(rectangle);
        }

        static void PrintFigure(Figure figure)
        {
            Console.WriteLine("I am a {0}. My perimeter is {1:f2}. My surface is {2:f2}.",
                figure.GetType().Name, figure.CalcPerimeter(), figure.CalcSurface());
        }
    }
}