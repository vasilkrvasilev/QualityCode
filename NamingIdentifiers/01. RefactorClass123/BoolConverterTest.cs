using System;

// Rename the class from class_123 to BoolConverterTest
// Use CAPITAL_LETTERS for the name of the const
// Rename the method to Main()
// Create object of class BoolConverter with name boolConverter
public class BoolConverterTest
{
    public const int MAX_COUNT = 6;

    public static void Main()
    {
        BoolConverter boolConverter = new BoolConverter();
        boolConverter.PrintBoolToString(true);
    }
}
