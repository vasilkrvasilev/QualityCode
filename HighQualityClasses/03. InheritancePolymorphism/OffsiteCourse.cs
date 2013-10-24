using System;
using System.Collections.Generic;
using System.Text;

// Inherit class Course
// Create  property Town
// Inherit base constructors and assing value of property Town in them
// Create additional constructor with four parameters
// Override method ToString() using the base method
// Create method ChangeTown() to change value of property Town
namespace InheritancePolymorphism
{
    public class OffsiteCourse : Course
    {
        public string Town { get; private set; }

        public OffsiteCourse(string name)
            : base(name)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public void ChangeTown(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Invalid input! You should enter non-empty string for town name.");
            }

            this.Town = name;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { ");
            result.Append(base.ToString());

            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}