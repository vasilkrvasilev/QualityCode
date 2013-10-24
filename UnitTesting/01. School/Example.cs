using System;
using System.Linq;

// Create object of type School, Course and Student
public class Example
{
    static void Main()
    {
        School school = new School();
        Course course = new Course();
        Student student = new Student("John", school);
    }
}