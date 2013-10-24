using System;

// Rename the class to Figure and create private fields and public properties width and height
// Rename the method to RotateFigure and add it to the class
// Rename the parameters of the method to currentFigure and rotationAngleInRadians
// Create two variables rotatedWidth and rotatedHeight to keep new values of width and height
// Create new Figure - rotatedFigure and return it
// Add Main() method
public class Figure
{
    private double width;
    private double height;

    public Figure(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width
    {
        get { return this.width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid input! The width should be positive number.");
            }

            this.width = value;
        }
    }

    public double Height
    {
        get { return this.height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid input! The height should be positive number.");
            }

            this.height = value;
        }
    }

    public static Figure RotateFigure(Figure currentFigure, double rotationAngleInRadians)
    {
        double rotatedWidth = Math.Abs(Math.Cos(rotationAngleInRadians)) * currentFigure.Width +
            Math.Abs(Math.Sin(rotationAngleInRadians)) * currentFigure.Height;
        double rotatedHeight = Math.Abs(Math.Sin(rotationAngleInRadians)) * currentFigure.Width +
            Math.Abs(Math.Cos(rotationAngleInRadians)) * currentFigure.Height;
        Figure rotatedFigure = new Figure(rotatedWidth, rotatedHeight);

        return rotatedFigure;
    }

    static void Main()
    {
        Figure.RotateFigure(new Figure(1, 1), 1);
    }
}
