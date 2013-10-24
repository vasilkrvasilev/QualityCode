using System;
using System.Collections.Generic;

// Use classes Utils, Exam, ExamResult, CSharpExam, SimpleMathExam and Student
// Use more describtive variable names
// Use if-else instead of try-catch
class Exceptions
{
    static void Main()
    {
        var substring = Utils.Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substring);

        var subArray = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subArray));

        var fullArray = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", fullArray));

        var emptyArray = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyArray));

        Console.WriteLine(Utils.ExtractEnding("I love C#", 2));
        Console.WriteLine(Utils.ExtractEnding("Nakov", 4));
        Console.WriteLine(Utils.ExtractEnding("beer", 4));
        Console.WriteLine(Utils.ExtractEnding("Hi", 100));

        if (Utils.CheckPrime(23))
        {
            Console.WriteLine("23 is prime.");
        }
        else
        {
            Console.WriteLine("23 is not prime");
        }

        if (Utils.CheckPrime(33))
        {
            Console.WriteLine("33 is prime.");
        }
        else
        {
            Console.WriteLine("33 is not prime");
        }

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}