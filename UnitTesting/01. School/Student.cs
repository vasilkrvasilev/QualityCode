using System;
using System.Linq;

// Create class Student with field and property name and second property StudentNumber
// Constructor use name and school to create a student from the school
// StudentNumber is initialize in the constructor calling school.GetStudentNumber()
// This insure that each student in the school has unique StudentNumber
public class Student
{
    private string name;

    public int StudentNumber { get; private set; }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(
                    "Invalid input! You should enter not empty string for student name.");
            }

            this.name = value;
        }
    }

    public Student(string name, School school)
    {
        if (school == null)
        {
            throw new ArgumentNullException(
                    "Invalid input! You cannot add student to null object.");
        }

        this.Name = name;
        this.StudentNumber = school.GetStudentNumber();
    }
}