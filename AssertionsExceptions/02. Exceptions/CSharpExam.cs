using System;

// Inherit class abstract Exam
// Extract constant MAX_POINTS
// Create private field score and public property to verify its value
// Override method Check()
public class CSharpExam : Exam
{
    public const int MAX_POINTS = 100;
    private int score;

    public int Score
    {
        get { return this.score; }
        set
        {
            if (value < 0 || value > MAX_POINTS)
            {
                throw new ArgumentException(string.Format(
                    "Invalid input! You should enter number in the interval [0,{0}] for scores.", MAX_POINTS));
            }

            this.score = value;
        }
    }

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, 0, MAX_POINTS, "Exam results calculated by score.");
    }
}