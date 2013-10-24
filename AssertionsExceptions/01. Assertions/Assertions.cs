using System;
using System.Diagnostics;
using System.Linq;

// Add preconditions and postconditions using assertions
class Assertions
{
    // Add precondition - the array should be not empty
    // Add postcondition - each next element should be equal or bigger then the previous one
    public static void SelectionSort<T>(T[] array) where T : IComparable<T>
    {
        Debug.Assert(array.Length > 0, "You enter empty array.");

        for (int index = 0; index < array.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(array, index, array.Length - 1);
            Swap(ref array[index], ref array[minElementIndex]);
        }

        bool correct = true;
        for (int count = 0; count < array.Length - 1; count++)
        {
            if (array[count].CompareTo(array[count + 1]) >= 0)
            {
                correct = false;
                break;
            }
        }

        Debug.Assert(correct, "The array is not sorted correctly.");
    }

    // Add preconditions - startIndex and endIndex should be in the intervals [0, array.Length) and (0, array.Length]
    // Add preconditions - startIndex should be smaller then endIndex
    private static int FindMinElementIndex<T>(T[] array, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        // Checked in SelectionSort<T>()
        //Debug.Assert(array.Length > 0, "You enter empty array.");
        Debug.Assert(startIndex >= 0 && startIndex < array.Length - 1,
            string.Format("You enter negative start index or bigger than {0}.", array.Length - 2));
        Debug.Assert(endIndex > 0 && endIndex < array.Length,
            string.Format("You enter non-positive end index or bigger than {0}.", array.Length - 1));
        Debug.Assert(startIndex < endIndex, "The start index is bigger or equal to the end index.");

        int elementIndex = startIndex;
        for (int index = startIndex + 1; index <= endIndex; index++)
        {
            if (array[index].CompareTo(array[elementIndex]) < 0)
            {
                elementIndex = index;
            }
        }

        return elementIndex;
    }

    private static void Swap<T>(ref T firstValue, ref T secondValue)
    {
        T exchangeValue = firstValue;
        firstValue = secondValue;
        secondValue = exchangeValue;
    }

    // Add precondition - the array should be not empty
    public static int BinarySearch<T>(T[] array, T value) where T : IComparable<T>
    {
        Debug.Assert(array.Length > 0, "You enter empty array.");

        return BinarySearch(array, value, 0, array.Length - 1);
    }

    // Add preconditions - startIndex and endIndex should be in the interval [0, array.Length)
    // Add preconditions - startIndex should be equal or smaller then endIndex
    // Add preconditions - the array should be sorted
    // Add postcondition - if the array contains surched value, the method should find it
    private static int BinarySearch<T>(T[] array, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        // Checked in BinarySearch<T>()
        //Debug.Assert(array.Length > 0, "You enter empty array.");
        Debug.Assert(startIndex >= 0 && startIndex < array.Length,
            string.Format("You enter negative start index or bigger than {0}.", array.Length - 1));
        Debug.Assert(endIndex >= 0 && endIndex < array.Length,
            string.Format("You enter non-positive end index or bigger than {0}.", array.Length - 1));
        Debug.Assert(startIndex <= endIndex, "The start index is bigger than the end index.");

        bool sorted = true;
        for (int count = 0; count < array.Length - 1; count++)
        {
            if (array[count].CompareTo(array[count + 1]) >= 0)
            {
                sorted = false;
                break;
            }
        }

        Debug.Assert(sorted, "Yo enter unsorted array.");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (array[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (array[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the left half
                endIndex = midIndex - 1;
            }
        }

        for (int count = 0; count < array.Length; count++)
        {
            Debug.Assert(!array[count].Equals(value), "The binary search is not working correctly.");
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] array = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("Array = [{0}]", string.Join(", ", array));
        SelectionSort(array);
        Console.WriteLine("Sorted array = [{0}]", string.Join(", ", array));

        SelectionSort(new int[0]);
        SelectionSort(new int[1]);

        Console.WriteLine(BinarySearch(array, -1000));
        Console.WriteLine(BinarySearch(array, 0));
        Console.WriteLine(BinarySearch(array, 17));
        Console.WriteLine(BinarySearch(array, 10));
        Console.WriteLine(BinarySearch(array, 1000));
    }
}