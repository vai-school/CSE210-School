using System;

class Menu
{
    public int DisplayMenu()
    {
        Console.WriteLine("1. New Entry");
        Console.WriteLine("2. Display Journal");
        Console.WriteLine("3. Save Journal");
        Console.WriteLine("4. Load Journal");
        Console.WriteLine("5. Exit");

        Console.Write("Where do you want to go?: ");
        int choice = int.Parse(Console.ReadLine());

        return choice;
    }
}