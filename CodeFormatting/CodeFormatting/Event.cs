using System;
using System.Text;

// Extract class Event in separate file - Event.cs
// Extract the date format and separator as constants
// Change the access modificator of class fields from public to private 
// Create public properties
// Use this.Property instead of field, string instead of String and string.Empty instead of ""

public class Event : IComparable
{
    public const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
    public const string SEPARATOR = "|";
    private DateTime date;
    private string title;
    private string location;

    public Event(DateTime date, string title, string location)
    {
        this.Date = date;
        this.Title = title;
        this.Location = location;
    }

    public DateTime Date
    {
        get { return this.date; }
        set { this.date = value; }
    }

    public string Title
    {
        get { return this.title; }
        set { this.title = value; }
    }

    public string Location
    {
        get { return this.location; }
        set { this.location = value; }
    }
    
    public int CompareTo(object obj)
    {
        Event other = obj as Event;
        int byDate = this.Date.CompareTo(other.Date);
        int byTitle = this.Title.CompareTo(other.Title);
        int byLocation = this.Location.CompareTo(other.Location);
        if (byDate == 0)
        {
            if (byTitle == 0)
            {
                return byLocation;
            }
            else
            {
                return byTitle;
            }
        }
        else
        {
            return byDate;
        }
    }

	public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(this.Date.ToString(DATE_FORMAT));
        result.Append(SEPARATOR + this.Title);
        if ((this.Location != null) && (this.Location != string.Empty))
        {
            result.Append(SEPARATOR + this.Location);
        }

        return result.ToString();
    }
}