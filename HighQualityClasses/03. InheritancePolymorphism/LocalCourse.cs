using System;
using System.Collections.Generic;
using System.Text;

// Inherit class Course
// Create property Lab
// Inherit base constructors and assing value of property Lab in them
// Create additional constructor with four parameters
// Override method ToString() using the base method
// Create method ChangeLab() to change value of property Lab
namespace InheritancePolymorphism
{
    public class LocalCourse : Course
    {
        public string Lab { get; private set; }

        public LocalCourse(string name)
            : base(name)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public void ChangeLab(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Invalid input! You should enter non-empty string for lab name.");
            }

            this.Lab = name;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { ");
            result.Append(base.ToString());

            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}