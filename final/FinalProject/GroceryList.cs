using System;
using System.Collections.Generic;

class GroceryList {
    private static List<string> items = new List<string>();

    public static void GroceryMenu() {
        int choice = 0;
        while (choice != 5) {
            Console.WriteLine("=== Grocery List ===");
            Console.WriteLine("1. Add item");
            Console.WriteLine("2. Add missing recipe ingredients");
            Console.WriteLine("3. View list");
            Console.WriteLine("4. Remove item");
            Console.WriteLine("5. Go Back");
            Console.Write("Choice: ");

            if (int.TryParse(Console.ReadLine(), out choice)) {
                if (choice == 1) {
                    AddItem();
                } else if (choice == 2) {
                    AddFromRecipe();
                } else if (choice == 3) {
                    ShowList();
                } else if (choice == 4) {
                    RemoveItem();
                } else if (choice == 5) {
                    Console.WriteLine("Going back...\n");
                } else {
                    Console.WriteLine("Please enter a number between 1 and 5.\n");
                }
            } else {
                Console.WriteLine("Please enter a number.\n");
            }
        }
    }

    static void AddItem() {
        Console.Write("Item to add: ");
        string item = Console.ReadLine();
        items.Add(item);
        Console.WriteLine(item + " added!\n");
    }

    static void AddFromRecipe() {
        RecipeList.ShowAllRecipes();
        Console.Write("Which recipe? (number): ");
        if (int.TryParse(Console.ReadLine(), out int index)) {
            List<Recipe> allRecipes = RecipeList.GetAllRecipes();
            if (index >= 1 && index <= allRecipes.Count) {
                Recipe recipe = allRecipes[index - 1];
                List<string> recipeIngredients = recipe.GetIngredients();
                int added = 0;

                for (int i = 0; i < recipeIngredients.Count; i++) {
                    if (!Pantry.HasIngredient(recipeIngredients[i])) {
                        items.Add(recipeIngredients[i]);
                        added++;
                    }
                }

                if (added == 0) {
                    Console.WriteLine("You already have everything for this recipe!\n");
                } else {
                    Console.WriteLine(added + " ingredient(s) added to grocery list.\n");
                }
            } else {
                Console.WriteLine("Invalid number.\n");
            }
        } else {
            Console.WriteLine("Please enter a number.\n");
        }
    }

    static void ShowList() {
        if (items.Count == 0) {
            Console.WriteLine("Your grocery list is empty.\n");
            return;
        }
        Console.WriteLine("\n=== Grocery List ===");
        for (int i = 0; i < items.Count; i++) {
            Console.WriteLine((i + 1) + ". " + items[i]);
        }
        Console.WriteLine();
    }

    static void RemoveItem() {
        if (items.Count == 0) {
            Console.WriteLine("Your grocery list is empty.\n");
            return;
        }
        ShowList();
        Console.Write("Which item to remove? (number): ");
        if (int.TryParse(Console.ReadLine(), out int index)) {
            if (index >= 1 && index <= items.Count) {
                string name = items[index - 1];
                items.RemoveAt(index - 1);
                Console.WriteLine(name + " removed!\n");
            } else {
                Console.WriteLine("Invalid number.\n");
            }
        } else {
            Console.WriteLine("Please enter a number.\n");
        }
    }

    public static List<string> GetItems() {
        return items;
    }

    public static void SetItems(List<string> loaded) {
        items = loaded;
    }
}