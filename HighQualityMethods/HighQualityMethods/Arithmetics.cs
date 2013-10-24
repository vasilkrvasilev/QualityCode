using System;

// Extract NumberToDigit(), FindMax(), PrintAsFloatingPointNumber(), PrintAsPercentage() and PrintAsAlingNumber()
// Verify their input parameters in the beginning of the method and throw an exceptions if they are not correct
// Use additional variables - digitName in NumberToDigit(), maxElement in FindMax() (count instead of i)
// Separate method PrintAsNumber() to PrintAsFloatingPointNumber(), PrintAsPercentage() and PrintAsAlingNumber()
// Use additional variable - numberToPrint
public class Arithmetics
{
    public static string NumberToDigit(int number)
    {
        if (number < 0 || number > 9)
        {
            throw new ArgumentException("Invalid input! You should enter number in the interval [0,9]");
        }

        string digitName = string.Empty;
        switch (number)
        {
            case 0:
                digitName = "zero";
                break;
            case 1:
                digitName = "one";
                break;
            case 2:
                digitName = "two";
                break;
            case 3:
                digitName = "three";
                break;
            case 4:
                digitName = "four";
                break;
            case 5:
                digitName = "five";
                break;
            case 6:
                digitName = "six";
                break;
            case 7:
                digitName = "seven";
                break;
            case 8:
                digitName = "eight";
                break;
            case 9:
                digitName = "nine";
                break;
        }

        return digitName;
    }

    public static int FindMax(params int[] elements)
    {
        if (elements == null || elements.Length == 0)
        {
            throw new ArgumentException("Invalid input! You should enter non-empty array of integer numbers");
        }

        int maxElement = elements[0];
        for (int count = 1; count < elements.Length; count++)
        {
            if (elements[count] > maxElement)
            {
                maxElement = elements[count];
            }
        }

        return maxElement;
    }

    public static void PrintAsFloatingPointNumber(object number)
    {
        double numberToPrint;
        if (!double.TryParse(number.ToString(), out numberToPrint))
        {
            throw new ArgumentException("Invalid input! You should enter integer or floating point number");
        }

        Console.WriteLine("{0:f2}", number);
    }

    public static void PrintAsPercentage(object number)
    {
        double numberToPrint;
        if (!double.TryParse(number.ToString(), out numberToPrint))
        {
            throw new ArgumentException("Invalid input! You should enter integer or floating point number");
        }

        Console.WriteLine("{0:p0}", number);
    }

    public static void PrintAsAlingNumber(object number)
    {
        double numberToPrint;
        if (!double.TryParse(number.ToString(), out numberToPrint))
        {
            throw new ArgumentException("Invalid input! You should enter integer or floating point number");
        }

        Console.WriteLine("{0,8}", number);
    }
}