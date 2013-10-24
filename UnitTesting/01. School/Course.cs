using System;
using System.Collections.Generic;
using System.Linq;

// Create class Course with property ListOfStudents which is initialize in the constructor
// The method AddStudent add student to ListOfStudents if its size is less than 30
// The method RemoveStudent remove student from ListOfStudents if its size is bigger than 0
public class Course
{
    public List<Student> ListOfStudents { get; private set; }

    public Course()
    {
        this.ListOfStudents = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(
                    "Invalid input! You cannot add null object to the course.");
        }

        if (this.ListOfStudents.Count >= 30)
        {
            throw new ArgumentException(
                    "All places in the course are already reserved! There are no more free places in the course.");
        }

        this.ListOfStudents.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(
                    "Invalid input! You cannot remove null object from the course.");
        }

        if (this.ListOfStudents.Count == 0)
        {
            throw new ArgumentException("There are no signed students for the course.");
        }

        this.ListOfStudents.Remove(student);
    }
}