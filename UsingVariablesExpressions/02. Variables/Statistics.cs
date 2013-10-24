using System;

// Create class Statistics with three methods PrintMax(), PrintAverage() and Print()
// Rename the input parameters to array, numberElements and number(for method Print())
// Use variables maxNumber, sum, averageSum and position instead of tmp, max and i
// Add Main() method
class Statistics
{
    public void PrintMax(double[] array, int numberElements)
    {
        double maxNumber = double.MinValue;
        for (int position = 0; position < numberElements; position++)
        {
            if (array[position] > maxNumber)
            {
                maxNumber = array[position];
            }
        }

        Print(maxNumber);
    }

    public void PrintAverage(double[] array, int numberElements)
    {
        double sum = 0;
        for (int position = 0; position < numberElements; position++)
        {
            sum += array[position];
        }

        double averageSum = sum / numberElements;
        Print(averageSum);
    }

    public void Print(double number)
    {
        Console.WriteLine(number);
    }

    static void Main()
    {
    }
}