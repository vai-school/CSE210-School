using System;

class Program
{
private BreathingActivity _breathing;
    private ReflectionActivity _reflection;
    private ListingActivity _listing;

    public Program()
    {
        _breathing = new BreathingActivity();
        _reflection = new ReflectionActivity();
        _listing = new ListingActivity();
    }

    public void Run()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to the Mindfulness App!");

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("  1. Breathing Activity");
            Console.WriteLine("  2. Reflection Activity");
            Console.WriteLine("  3. Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();
            Console.Write("Which activity would you like? ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                _breathing.Run();
            }
            else if (choice == "2")
            {
                _reflection.Run();
            }
            else if (choice == "3")
            {
                _listing.Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine();
                Console.WriteLine("Goodbye.");
                Console.WriteLine();
                break;
            }
            else
            {
                Console.WriteLine("Please enter 1, 2, 3, or 4.");
            }
        }
    }

    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }
}