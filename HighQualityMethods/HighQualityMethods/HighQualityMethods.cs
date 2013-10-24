using System;

// Use classes Arithmetics, Geometry and Student
class HighQualityMethods
{
    static void Main()
    {
        Console.WriteLine(Geometry.CalcTriangleArea(3, 4, 5));

        Console.WriteLine(Arithmetics.NumberToDigit(5));
        Console.WriteLine(Arithmetics.FindMax(5, -1, 3, 2, 14, 2, 3));

        Arithmetics.PrintAsFloatingPointNumber(1.3);
        Arithmetics.PrintAsPercentage(0.75);
        Arithmetics.PrintAsAlingNumber(2.30);

        Console.WriteLine(Geometry.CalcDistance(3, -1, 3, 2.5));
        Console.WriteLine("Horizontal? " + Geometry.CheckIsHorizontal(3, 3));
        Console.WriteLine("Vertical? " + Geometry.CheckIsVertical(-1, 2.5));

        Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");
        Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");
        Console.WriteLine("{0} older than {1} -> {2}",
            peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
    }
}