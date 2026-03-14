using System;
using System.Collections.Generic;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;
    static SaveAndLoad saveAndLoad = new SaveAndLoad();

    static void Main(string[] args)
    {
        int number = 0;

        while (number != 6)
        {
            number = DisplayMenu();

            if (number == 1)
            {
                CreateGoal();
            }
            else if (number == 2)
            {
                ListGoals();
            }
            else if (number == 3)
            {
                RecordEvent();
            }
            else if (number == 4)
            {
                saveAndLoad.SaveGoals(goals, score);
            }
            else if (number == 5)
            {
                saveAndLoad.LoadGoals(goals, ref score);
            }
            else if (number == 6)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Please enter a number between 1 and 6.\n");
            }
        }
    }

    static int DisplayMenu()
    {
        Console.WriteLine($"\nYou have {score} points.\n");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Record Event");
        Console.WriteLine("4. Save Goals");
        Console.WriteLine("5. Load Goals");
        Console.WriteLine("6. Exit");
        Console.Write("What would you like to do?: ");
        int choice = int.Parse(Console.ReadLine());
        Console.WriteLine();
        return choice;
    }

    static void CreateGoal()
    {
        Console.WriteLine("What kind of goal do you want to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Your choice: ");
        int type = int.Parse(Console.ReadLine());

        Console.Write("Name of goal: ");
        string name = Console.ReadLine();

        Console.Write("Short description: ");
        string description = Console.ReadLine();

        if (type == 1)
        {
            goals.Add(new SimpleGoal(name, description, 25));
        }
        else if (type == 2)
        {
            goals.Add(new EternalGoal(name, description, 10));
        }
        else if (type == 3)
        {
            Console.Write("How many times does it need to be completed?: ");
            int required = int.Parse(Console.ReadLine());

            goals.Add(new ChecklistGoal(name, description, 10, required, 70));
        }
        else
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Console.WriteLine("Goal created!\n");
    }

    static void ListGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals yet.\n");
            return;
        }

        Console.WriteLine("Your Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDisplayString()}");
        }
        Console.WriteLine();
    }

    static void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to record.\n");
            return;
        }

        ListGoals();
        Console.Write("Which goal did you complete? (enter number): ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= goals.Count)
        {
            Console.WriteLine("Invalid selection.\n");
            return;
        }

        int earned = goals[index].RecordEvent();
        score += earned;
        Console.WriteLine($"You earned {earned} points! Total score: {score}\n");
    }
}