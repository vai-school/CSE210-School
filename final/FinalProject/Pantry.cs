using System;
using System.Collections.Generic;

class Pantry {
    private static List<Ingredient> ingredients = new List<Ingredient>();
    private static List<FoodItem> foodItems = new List<FoodItem>();

    public static void PantryMenu() {
        int choice = 0;

        while (choice != 7) {
            Console.WriteLine("=== Pantry ===");
            Console.WriteLine("1. Add Ingredient");
            Console.WriteLine("2. Add Food Item");
            Console.WriteLine("3. View Ingredients");
            Console.WriteLine("4. View Food Items");
            Console.WriteLine("5. Update Ingredient Quantity");
            Console.WriteLine("6. Remove Ingredient");
            Console.WriteLine("7. Go Back");
            Console.Write("Choice: ");

            if (int.TryParse(Console.ReadLine(), out choice)) {
                if (choice == 1) {
                    AddIngredient();
                } else if (choice == 2) {
                    AddFoodItem();
                } else if (choice == 3) {
                    ShowIngredients();
                } else if (choice == 4) {
                    ShowFoodItems();
                } else if (choice == 5) {
                    UpdateQuantity();
                } else if (choice == 6) {
                    RemoveIngredient();
                } else if (choice == 7) {
                    Console.WriteLine("Going back...\n");
                } else {
                    Console.WriteLine("Please enter a number between 1 and 7.\n");
                }
            } else {
                Console.WriteLine("Please enter a number.\n");
            }
        }
    }

    public static void AddIngredient() {
        Console.WriteLine("\n1. Dry Good");
        Console.WriteLine("2. Produce");
        Console.WriteLine("3. Dairy");
        Console.WriteLine("4. Spice");
        Console.Write("Type (1-4): ");

        if (int.TryParse(Console.ReadLine(), out int type)) {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Quantity: ");
            string quantity = Console.ReadLine();

            Ingredient newIngredient = null;

            if (type == 1) {
                newIngredient = new DryGood(name, quantity);
            } else if (type == 2) {
                Console.Write("Freshness (Fresh/Medium/Old): ");
                string freshness = Console.ReadLine();
                newIngredient = new Produce(name, quantity, freshness);
            } else if (type == 3) {
                newIngredient = new Dairy(name, quantity);
            } else if (type == 4) {
                Console.Write("Organic? (yes/no): ");
                bool isOrganic = Console.ReadLine().ToLower() == "yes";
                newIngredient = new Spice(name, quantity, isOrganic);
            } else {
                Console.WriteLine("Invalid type.\n");
                return;
            }

            ingredients.Add(newIngredient);
            Console.WriteLine(name + " added!\n");
        } else {
            Console.WriteLine("Please enter a number.\n");
        }
    }

    public static void AddFoodItem() {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Category (e.g. snack, drink, frozen): ");
        string category = Console.ReadLine();
        Console.Write("Quantity: ");
        string quantity = Console.ReadLine();

        foodItems.Add(new FoodItem(name, category, quantity));
        Console.WriteLine(name + " added!\n");
    }

    public static void ShowIngredients() {
    Console.WriteLine("\n=== Ingredients ===");
    if (ingredients.Count == 0) {
        Console.WriteLine("No ingredients yet.\n");
        return;
    }
    for (int i = 0; i < ingredients.Count; i++) {
        Console.Write((i + 1) + ". [" + ingredients[i].GetIngredientType() + "] ");
        ingredients[i].Display();
    }
    Console.WriteLine();
    }

    public static void ShowFoodItems() {
        Console.WriteLine("\n=== Food Items ===");
        if (foodItems.Count == 0) {
            Console.WriteLine("No food items yet.\n");
            return;
        }
        for (int i = 0; i < foodItems.Count; i++) {
            Console.Write((i + 1) + ". ");
            foodItems[i].Display();
        }
        Console.WriteLine();
    }

    public static void UpdateQuantity() {
        if (ingredients.Count == 0) {
            Console.WriteLine("No ingredients yet.\n");
            return;
        }
        ShowIngredients();
        Console.Write("Which ingredient? (number): ");
        if (int.TryParse(Console.ReadLine(), out int index)) {
            if (index >= 1 && index <= ingredients.Count) {
                Console.WriteLine("Current: " + ingredients[index - 1].GetQuantity());
                Console.Write("New quantity: ");
                ingredients[index - 1].SetQuantity(Console.ReadLine());
                Console.WriteLine("Updated!\n");
            } else {
                Console.WriteLine("Invalid number.\n");
            }
        } else {
            Console.WriteLine("Please enter a number.\n");
        }
    }

    public static void RemoveIngredient() {
        if (ingredients.Count == 0) {
            Console.WriteLine("No ingredients yet.\n");
            return;
        }
        ShowIngredients();
        Console.Write("Which ingredient to remove? (number): ");
        if (int.TryParse(Console.ReadLine(), out int index)) {
            if (index >= 1 && index <= ingredients.Count) {
                string name = ingredients[index - 1].GetName();
                ingredients.RemoveAt(index - 1);
                Console.WriteLine(name + " removed!\n");
            } else {
                Console.WriteLine("Invalid number.\n");
            }
        } else {
            Console.WriteLine("Please enter a number.\n");
        }
    }

    public static bool HasIngredient(string ingredientName) {
        for (int i = 0; i < ingredients.Count; i++) {
            if (ingredients[i].GetName() == ingredientName) {
                return true;
            }
        }
        return false;
    }

    public static Ingredient GetIngredient(string ingredientName) {
        for (int i = 0; i < ingredients.Count; i++) {
            if (ingredients[i].GetName() == ingredientName) {
                return ingredients[i];
            }
        }
        return null;
    }

    public static List<Ingredient> GetAllIngredients() {
        return ingredients;
    }

    public static List<FoodItem> GetAllFoodItems() {
        return foodItems;
    }

    public static void SetIngredients(List<Ingredient> loaded) {
        ingredients = loaded;
    }

    public static void SetFoodItems(List<FoodItem> loaded) {
        foodItems = loaded;
    }
}