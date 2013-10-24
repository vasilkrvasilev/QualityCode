using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Create class Course and extract common functionality of LocalCourse and OffsiteCourse in it
// Create private field name and property Name to verify its value
// Create properties TeacherName and Students
// Create three constructors and initialize all properties in each of them
// Extract methods GetStudentsAsString() and ToString() in the class
// Create methods ChangeTeacher(), AddStudents() and AddStudent() to change values of properties TeacherName and Students
namespace InheritancePolymorphism
{
    public class Course
    {
        private string name;

        public string TeacherName { get; protected set; }
        public IList<string> Students { get; protected set; }

        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Invalid input! You should enter non-empty string for course name.");
                }

                this.name = value;
            }
        }

        public Course(string name)
        {
            this.Name = name;
            this.TeacherName = null;
            this.Students = new List<string>();
        }

        public Course(string courseName, string teacherName)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = new List<string>();
        }

        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public void ChangeTeacher(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Invalid input! You should enter non-empty string for teacher name.");
            }

            this.TeacherName = name;
        }

        public void AddStudents(List<string> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException(
                    "Invalid input! You should enter non-empty collection of students.");
            }

            for (int count = 0; count < students.Count; count++)
            {
                AddStudent(students[count]);
            }
        }

        public void AddStudent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Invalid input! You should enter non-empty string for student name.");
            }

            this.Students.Add(name);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Name = ");
            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            return result.ToString();
        }
    }
}