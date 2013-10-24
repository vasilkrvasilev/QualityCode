using System;

// Extract constants and rename them
// Use properties IsPeeled and IsFresh instead of HasNotBeenPeeled and IsRotten
// Create and use variables rowIsInner, columnIsInner and shouldVisitCell
// Create methods Cook(Vegetable vegetable) and VisitCell()
public class RefactorIfStatement
{
    const int MAX_ROW = int.MaxValue;
    const int MIN_ROW = int.MinValue;
    const int MAX_COLUMN = int.MaxValue;
    const int MIN_COLUMN = int.MinValue;

    static void Main()
    {
        Potato potato = new Potato();
        if (potato != null)
        {
            if (potato.IsPeeled && potato.IsFresh)
            {
                Cook(potato);
            }
        }

        int row = int.Parse(Console.ReadLine());
        int column = int.Parse(Console.ReadLine());
        bool rowIsInner = (row >= MIN_ROW) && (row <= MAX_ROW);
        bool columnIsInner = (column >= MIN_COLUMN) && (column <= MAX_COLUMN);
        bool shouldVisitCell = true;

        if (rowIsInner && columnIsInner && shouldVisitCell)
        {
            VisitCell();
        }
    }

    static void Cook(Vegetable vegetable)
    {
        vegetable.IsCooked = true;
    }

    static void VisitCell()
    {
        Console.WriteLine("The cell is visited");
    }
}