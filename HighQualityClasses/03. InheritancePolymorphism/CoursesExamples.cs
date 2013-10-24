using System;
using System.Collections.Generic;

// Use classes Course, LocalCourse and OffsiteCourse
namespace InheritancePolymorphism
{
    class CoursesExamples
    {
        static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases");
            Console.WriteLine(localCourse.ToString());

            localCourse.ChangeLab("Enterprise");
            Console.WriteLine(localCourse);

            List<string> localStudents = new List<string>() { "Peter", "Maria" };
            localCourse.AddStudents(localStudents);
            Console.WriteLine(localCourse.ToString());

            localCourse.ChangeTeacher("Svetlin Nakov");
            localCourse.AddStudent("Milena");
            localCourse.AddStudent("Todor");
            Console.WriteLine(localCourse.ToString());

            List<string> offsiteStudents = new List<string>() { "Thomas", "Ani", "Steve" };
            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development", "Mario Peshev", offsiteStudents);
            Console.WriteLine(offsiteCourse.ToString());
        }
    }
}