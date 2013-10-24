using System;

// Create privite fields firstName, lastName, additionalInfo and birdDate
// Verify the value of the fields in public properties
// Verify and set the value of birthDate in the constructor and made readonly public property
// Use directly the property BirthDate in the method IsOlderThan()
public class Student
{
    private string firstName;
    private string lastName;
    private string additionalInfo;
    private DateTime birthDate;

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input! You should enter student's first name");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input! You should enter student's last name");
            }

            this.lastName = value;
        }
    }

    public string AdditionalInfo
    {
        get { return this.additionalInfo; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 10)
            {
                throw new ArgumentException(
                    "Invalid input! You should enter at least student's birth date as additional information");
            }

            this.additionalInfo = value;
        }
    }

    public DateTime BirthDate
    {
        get { return this.birthDate; }
    }

    public Student(string firstName, string lastName, string additionalInfo)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.AdditionalInfo = additionalInfo;
        
        if (!DateTime.TryParse(this.AdditionalInfo.Substring(this.AdditionalInfo.Length - 10), out this.birthDate))
        {
            throw new ArgumentException(
                "Invalid input! You should enter student's birth date in format dd.MM.yyyy");
        }
    }

    public bool IsOlderThan(Student other)
    {
        return this.BirthDate > other.BirthDate;
    }
}