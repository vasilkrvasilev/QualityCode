using System;
using System.Linq;
using System.Collections.Generic;

// Create private fields firstName, lastName and exams
// Create public properties to verify their values
// Use additional variables to separate complex expressions - numberExams, current, gradeToMinGrade and maxGradeToMinGrade
// Use count instead of i
public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams;

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(
                    "Invalid input! You should enter non-empty string for first name.");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(
                    "Invalid input! You should enter non-empty string for last name.");
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get { return this.exams; }
        set
        {
            if (value == null || value.Count == 0)
            {
                throw new ArgumentNullException(
                    "Invalid input! You should enter non-empty collection for exams.");
            }

            this.exams = value;
        }
    }

    public Student(string firstName, string lastName, IList<Exam> exams)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public IList<ExamResult> CheckExams()
    {
        IList<ExamResult> results = new List<ExamResult>();
        for (int count = 0; count < this.Exams.Count; count++)
        {
            results.Add(this.Exams[count].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        int numberExams = this.Exams.Count;
        double[] examScore = new double[numberExams];
        IList<ExamResult> examResults = this.CheckExams();
        for (int count = 0; count < numberExams; count++)
        {
            ExamResult current = examResults[count];
            double gradeToMinGrade = (double)current.Grade - current.MinGrade;
            double maxGradeToMinGrade = (double)current.MaxGrade - current.MinGrade;
            examScore[count] = gradeToMinGrade / maxGradeToMinGrade;
        }

        return examScore.Average();
    }
}