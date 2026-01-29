using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        Prompt prompt = new Prompt();
        Journal journal = new Journal();
        int number = 0;

        while (number != 5)
        {
            number = menu.DisplayMenu();

            if (number == 1)
            {
                Console.WriteLine("New Entry Selected!");
                string _prompts = prompt.GetPrompt();
                Console.WriteLine(_prompts);
                Console.Write("> ");
                string response = Console.ReadLine();
                journal.AddEntry(_prompts, response);
                Console.WriteLine("Entry added!\n");
            }
            else if (number == 2)
            {
                Console.WriteLine("Displaying Journal...");
                journal.DisplayEntries();
            }
            else if (number == 3)
            {
                Console.WriteLine("Saving Journal...");
                journal.SaveEntries();
            }
            else if (number == 4)
            {
                Console.WriteLine("Loading Journal...");
                journal.LoadEntries();
            }
            else if (number == 5)
            {
                Console.WriteLine("Exiting...");
            }
            else
            {
                Console.WriteLine("Put something between 1 and 5\n");
            }
        }
    }
}