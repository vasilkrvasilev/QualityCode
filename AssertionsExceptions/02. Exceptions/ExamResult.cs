using System;

// Create private fields grade, minGrade, maxGrade and comments
// Create public properties to verify their values
// Check in the constructor if the maxGrade is smaller then minGrade and throw exception
public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public int Grade
    {
        get { return this.grade; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "Invalid input! You should enter non-negative number for grade.");
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get { return this.minGrade; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "Invalid input! You should enter non-negative number for min grade.");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get { return this.maxGrade; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "Invalid input! You should enter non-negative number for min grade.");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get { return this.comments; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(
                    "Invalid input! You should enter non-empty string for comments.");
            }

            this.comments = value;
        }
    }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException(
                "Invalid input! You should enter max grade bigger than min grade.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}