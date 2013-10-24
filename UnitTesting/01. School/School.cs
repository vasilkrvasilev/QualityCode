using System;
using System.Linq;

// Create class School with field and property lastStudentNumber
// It is initialize with 10000 (down limit) and cannot be bigger than 99999 (upper limit)
// The method GetStudentNumber return next free student number and update LastStudentNumber
public class School
{
    private int lastStudentNumber;

    private int LastStudentNumber 
    {
        get { return this.lastStudentNumber; }
        set
        {
            if (value > 99999)
            {
                throw new ArgumentException(
                    "All student numbers are already reserved! There are no more free student numbers.");
            }

            this.lastStudentNumber = value;
        }
    }

    public School()
    {
        this.LastStudentNumber = 10000;
    }

    public int GetStudentNumber()
    {
        int studentNumber = this.LastStudentNumber;
        this.LastStudentNumber++;
        return studentNumber;
    }
}