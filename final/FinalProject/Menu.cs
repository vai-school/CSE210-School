using System;

class Menu {
    public static int DisplayMenu() {
        Console.WriteLine("=== Food Planner ===");
        Console.WriteLine("1. Schedule");
        Console.WriteLine("2. Grocery List");
        Console.WriteLine("3. What can I make?");
        Console.WriteLine("4. Recipes");
        Console.WriteLine("5. Pantry");
        Console.WriteLine("6. Save");
        Console.WriteLine("7. Load");
        Console.WriteLine("8. Exit");
        Console.Write("Choice: ");
        if (int.TryParse(Console.ReadLine(), out int choice)) {
            Console.WriteLine();
            return choice;
        }
        Console.WriteLine("Please enter a number.\n");
        return -1;
    }
}