using System;

// Extract methods Initialize() and SearchValue()
// Use variable bool found instead of 666
// Use position instead of i
// Update position in loop declaration not in its body
public class RefactorLoop
{
    static void Main()
    {
        int[] array = Initialize();

        int expectedValue = int.Parse(Console.ReadLine());
        bool found = false;

        for (int position = 0; position < array.Length; position++)
        {
            found = SearchValue(array[position], position, expectedValue, found);
        }

        if (found)
        {
            Console.WriteLine("Value Found");
        }
    }

    static int[] Initialize()
    {
        int elements = int.Parse(Console.ReadLine());
        int[] array = new int[elements];
        for (int count = 0; count < elements; count++)
        {
            array[count] = int.Parse(Console.ReadLine());
        }

        return array;
    }

    private static bool SearchValue(int value, int position, int expectedValue, bool found)
    {
        if (position % 10 == 0)
        {
            Console.WriteLine(value);
            if (value == expectedValue)
            {
                found = true;
            }
        }
        else
        {
            Console.WriteLine(value);
        }

        return found;
    }
}