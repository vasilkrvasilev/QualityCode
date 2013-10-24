using System;

// Inherit class abstract Exam
// Extract constant NUMBER_PROBLEMS
// Create private field problemsSolved and public property to verify its value
// Override method Check()
public class SimpleMathExam : Exam
{
    public const int NUMBER_PROBLEMS = 10;
    private int problemsSolved;

    public int ProblemsSolved
    {
        get { return this.problemsSolved; }
        set
        {
            if (value < 0 || value > NUMBER_PROBLEMS)
            {
                throw new ArgumentException(string.Format(
                    "Invalid input! You should enter number in the interval [0,{0}] for solved problems.",
                    NUMBER_PROBLEMS));
            }

            this.problemsSolved = value;
        }
    }

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.ProblemsSolved, 0, NUMBER_PROBLEMS,
            "Exam results calculated by solved problems.");
    }
}