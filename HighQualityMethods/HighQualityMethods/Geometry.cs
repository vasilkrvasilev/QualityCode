using System;

// Extract CalcTriangleArea(), CheckIsHorizontal(), CheckIsVertical() and CalcDistance()
// Verify their input parameters in the beginning of the method and throw an exceptions if they are not correct
// Use sideA, sideB, sideC, semiPerimeter and squaredArea instead of a, b, c, s in CalcTriangleArea()
// Separate method CalcDistance() to CheckIsHorizontal(), CheckIsVertical() and CalcDistance()
// Use abscissaOne, abscissaTwo, ordinateOne, ordinateTwo and squaredDistance instead x1, x2, y1 and y2 in CalcDistance()
public class Geometry
{
    public static double CalcTriangleArea(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            throw new ArgumentException("Invalid input! You should enter only positive numbers for side length");
        }
        double semiPerimeter = (sideA + sideB + sideC) / 2;
        double squaredArea =
            semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC);
        double area = Math.Sqrt(squaredArea);
        return area;
    }

    public static bool CheckIsHorizontal(double ordinateOne, double ordinateTwo)
    {
        bool isHorizontal = (ordinateOne == ordinateTwo);
        return isHorizontal;
    }

    public static bool CheckIsVertical(double abscissaOne, double abscissaTwo)
    {
        bool isVertical = (abscissaOne == abscissaTwo);
        return isVertical;
    }

    public static double CalcDistance(double abscissaOne, double ordinateOne, double abscissaTwo, double ordinateTwo)
    {
        double squaredDistance =
            (abscissaTwo - abscissaOne) * (abscissaTwo - abscissaOne) +
            (ordinateTwo - ordinateOne) * (ordinateTwo - ordinateOne);
        double distance = Math.Sqrt(squaredDistance);
        return distance;
    }
}