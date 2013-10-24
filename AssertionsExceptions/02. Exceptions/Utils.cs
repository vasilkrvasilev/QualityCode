using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Extract methods from class Exceptions in class Utils
// Verify the value of input parameter through exceptions
// Use exception only to verify the value of input parameters
// Return result (not exception)
public class Utils
{
    public static T[] Subsequence<T>(T[] array, int startIndex, int count)
    {
        if (startIndex < 0)
        {
            throw new ArgumentException(
                    "Invalid input! You should enter non-negative number for start index.");
        }

        if (count < 0)
        {
            throw new ArgumentException(
                    "Invalid input! You should enter non-negative number for count.");
        }

        if (array.Length < startIndex || array.Length < startIndex + count)
        {
            throw new ArgumentException(string.Format(
                       "Invalid input! You should enter such start index and count so that" +
                       " start index and the sum of both is smaller than {0}.", array.Length));
        }

        List<T> result = new List<T>();
        for (int index = startIndex; index < startIndex + count; index++)
        {
            result.Add(array[index]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string input, int count)
    {
        int length = input.Length;
        if (count <= 0 || count > length)
        {
            throw new ArgumentException(string.Format(
                       "Invalid input! You should enter count in the interval [1,{0}].", length));
        }

        StringBuilder result = new StringBuilder();
        for (int index = length - count; index < length; index++)
        {
            result.Append(input[index]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        if (number <= 1)
        {
            throw new ArgumentException(
                    "Invalid input! You should enter number bigger than 1.");
        }

        bool isPrime = true;
        int maxDivisor = (int)Math.Sqrt(number);
        for (int divisor = 2; divisor <= maxDivisor; divisor++)
        {
            if (number % divisor == 0)
            {
                isPrime = false;
                break;
            }
        }

        return isPrime;
    }
}