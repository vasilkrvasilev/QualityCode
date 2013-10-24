using System;
using System.Collections.Generic;

// Create class Bowl with property Content and method Add(Vegetable vegetable)
public class Bowl
{
    private List<Vegetable> Content { get; set; }

    public Bowl()
    {
        this.Content = new List<Vegetable>();
    }

    public void Add(Vegetable vegetable)
    {
        if (vegetable.IsPeeled && vegetable.IsCut)
        {
            this.Content.Add(vegetable);
        }
        else
        {
            throw new ArgumentException("The vegetable shoud be peeled and cut.");
        }
    }
}
