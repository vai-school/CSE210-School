using System;

class Program {
    static void Main(string[] args) {
        int number = 0;

        while (number != 8) {
            number = Menu.DisplayMenu();

            if (number == 1) {
                Schedule.ScheduleMenu();
            } else if (number == 2) {
                GroceryList.GroceryMenu();
            } else if (number == 3) {
                Console.WriteLine("Random recipe: " + RecipeList.RandomRecipe() + "\n");
            } else if (number == 4) {
                RecipeList.RecipeMenu();
            } else if (number == 5) {
                Pantry.PantryMenu();
            } else if (number == 6) {
                SaveAndLoad.SaveAll();
            } else if (number == 7) {
                SaveAndLoad.LoadAll();
            } else if (number == 8) {
                Console.WriteLine("Goodbye!");
            } else if (number != -1) {
                Console.WriteLine("Please enter a number between 1 and 8.\n");
            }
        }
    }
}