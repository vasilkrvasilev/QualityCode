using System;
using System.Collections.Generic;

// Add methods GetPotato(), GetCarrot(), Peel(), Cut(), GetBowl() and Main()
// Sort them according to their use
public class Chef
{
    public void Cook()
    {
        Potato potato = GetPotato();
        Carrot carrot = GetCarrot();

        Peel(potato);
        Peel(carrot);

        Cut(potato);
        Cut(carrot);

        Bowl bowl = GetBowl();
        bowl.Add(carrot);
        bowl.Add(potato);
    }

    private Potato GetPotato()
    {
        Potato potato = new Potato();
        return potato;
    }

    private Carrot GetCarrot()
    {
        Carrot carrot = new Carrot();
        return carrot;
    }

    private void Peel(Vegetable vegetable)
    {
        vegetable.IsPeeled = true;
    }

    private void Cut(Vegetable vegetable)
    {
        vegetable.IsCut = true;
    }

    private Bowl GetBowl()
    {
        Bowl bowl = new Bowl();
        return bowl;
    }

    static void Main()
    {
        Chef chef = new Chef();
        chef.Cook();
    }
}