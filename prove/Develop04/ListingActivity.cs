using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _random;

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "Who are some of your personal heroes?",
            "What are things in your life that bring you joy?"
        };
    }

    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    public void Run()
    {
        StartMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine();
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.WriteLine("You have 10 seconds to think before you start: ");
        ShowCountdown(10);

        Console.WriteLine();
        Console.WriteLine("Start Listing. Press Enter after each one.");
        Console.WriteLine();

        int itemsListed = 0;
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < GetDuration())
        {
            string item = Console.ReadLine();
            if (item != "")
            {
                itemsListed++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {itemsListed} items!");

        EndMessage();
    }
}