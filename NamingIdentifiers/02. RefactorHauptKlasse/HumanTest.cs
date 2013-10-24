using System;

// Rename the class to HumanTest
// Rename the method to CreateHuman() and the input parameter to identificator
// Create object of class Human with name human
// Use "Male" and "Female instead of "Батката" and "Мацето"
// Create Main() method
public class HumanTest
{
    public static void CreateHuman(int identificator)
    {
        Human human = new Human();
        human.Identificator = identificator;
        if (identificator % 2 == 0)
        {
            human.Name = "Male";
            human.Gender = Gender.Male;
        }
        else
        {
            human.Name = "Female";
            human.Gender = Gender.Female;
        }
    }

    static void Main()
    {
        Console.WriteLine("Enter identificator");
        int identificator = int.Parse(Console.ReadLine());
        HumanTest.CreateHuman(identificator);
    }
}