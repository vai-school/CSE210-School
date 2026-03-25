using System;

class Schedule {
    static string[,] schedule = new string[7, 4];
    static string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
    static string[] meals = { "Breakfast", "Lunch", "Dinner", "Other" };

    public static void ScheduleMenu() {
        int choice = 0;
        while (choice != 4) {
            Console.WriteLine("=== Schedule ===");
            Console.WriteLine("1. Show Schedule");
            Console.WriteLine("2. Edit Schedule");
            Console.WriteLine("3. Clear a meal");
            Console.WriteLine("4. Go Back");
            Console.Write("Choice: ");

            if (int.TryParse(Console.ReadLine(), out choice)) {
                if (choice == 1) {
                    ShowSchedule();
                } else if (choice == 2) {
                    EditSchedule();
                } else if (choice == 3) {
                    ClearMeal();
                } else if (choice == 4) {
                    Console.WriteLine("Going back...\n");
                } else {
                    Console.WriteLine("Please enter a number between 1 and 4.\n");
                }
            } else {
                Console.WriteLine("Please enter a number.\n");
            }
        }
    }

    static void ShowSchedule() {
        Console.WriteLine();
        for (int d = 0; d < 7; d++) {
            Console.WriteLine(days[d] + ":");
            for (int m = 0; m < 4; m++) {
                string meal = schedule[d, m];
                if (meal == null || meal == "") {
                    meal = "(empty)";
                }
                Console.WriteLine("  " + meals[m] + ": " + meal);
            }
            Console.WriteLine();
        }
    }

    static void EditSchedule() {
        Console.WriteLine("Pick a day:");
        for (int i = 0; i < 7; i++) {
            Console.WriteLine((i + 1) + ". " + days[i]);
        }
        Console.Write("Day (1-7): ");
        if (!int.TryParse(Console.ReadLine(), out int dayNum)) {
            Console.WriteLine("Please enter a number.\n");
            return;
        }
        dayNum--;

        if (dayNum < 0 || dayNum > 6) {
            Console.WriteLine("Invalid day.\n");
            return;
        }

        Console.WriteLine("Pick a meal:");
        for (int i = 0; i < 4; i++) {
            Console.WriteLine((i + 1) + ". " + meals[i]);
        }
        Console.Write("Meal (1-4): ");
        if (!int.TryParse(Console.ReadLine(), out int mealNum)) {
            Console.WriteLine("Please enter a number.\n");
            return;
        }
        mealNum--;

        if (mealNum < 0 || mealNum > 3) {
            Console.WriteLine("Invalid meal.\n");
            return;
        }

        Console.Write("Recipe name (case sensitive): ");
        string recipeName = Console.ReadLine();

        if (RecipeList.HasRecipe(recipeName)) {
            schedule[dayNum, mealNum] = recipeName;
            Console.WriteLine("Schedule updated!\n");
        } else {
            Console.WriteLine("'" + recipeName + "' was not found in your recipes. Add it first.\n");
        }
    }

    static void ClearMeal() {
        Console.WriteLine("Pick a day:");
        for (int i = 0; i < 7; i++) {
            Console.WriteLine((i + 1) + ". " + days[i]);
        }
        Console.Write("Day (1-7): ");
        if (!int.TryParse(Console.ReadLine(), out int dayNum)) {
            Console.WriteLine("Please enter a number.\n");
            return;
        }
        dayNum--;

        Console.WriteLine("Pick a meal:");
        for (int i = 0; i < 4; i++) {
            Console.WriteLine((i + 1) + ". " + meals[i]);
        }
        Console.Write("Meal (1-4): ");
        if (!int.TryParse(Console.ReadLine(), out int mealNum)) {
            Console.WriteLine("Please enter a number.\n");
            return;
        }
        mealNum--;

        schedule[dayNum, mealNum] = "";
        Console.WriteLine("Meal cleared!\n");
    }

    public static string[,] GetSchedule() {
        return schedule;
    }

    public static void SetSchedule(string[,] loaded) {
        schedule = loaded;
    }
}