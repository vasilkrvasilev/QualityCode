using System;

// Extract class InClass_class_123 and rename it to BoolConverter
// Rename the method to PrintBoolToString() and the input parameter to input
// Rename the local variable to boolToString
public class BoolConverter
{
    public void PrintBoolToString(bool input)
    {
        string boolToString = input.ToString();
        Console.WriteLine(boolToString);
    }
}