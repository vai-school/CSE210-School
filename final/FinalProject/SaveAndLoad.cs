using System;
using System.Collections.Generic;
using System.IO;

class SaveAndLoad {
    public static void SaveAll() {
        SavePantry();
        SaveRecipes();
        SaveGroceryList();
        SaveSchedule();
        Console.WriteLine("Everything saved!\n");
    }

    public static void LoadAll() {
        LoadPantry();
        LoadRecipes();
        LoadGroceryList();
        LoadSchedule();
        Console.WriteLine("Everything loaded!\n");
    }

    static void SavePantry() {
        using (StreamWriter file = new StreamWriter("pantry.txt")) {
            List<Ingredient> ingredients = Pantry.GetAllIngredients();
            for (int i = 0; i < ingredients.Count; i++) {
                file.WriteLine(ingredients[i].GetType().Name);
                file.WriteLine(ingredients[i].GetName());
                file.WriteLine(ingredients[i].GetQuantity());
                file.WriteLine("---");
            }
        }

        using (StreamWriter file = new StreamWriter("fooditems.txt")) {
            List<FoodItem> items = Pantry.GetAllFoodItems();
            for (int i = 0; i < items.Count; i++) {
                file.WriteLine(items[i].GetName());
                file.WriteLine(items[i].GetCategory());
                file.WriteLine(items[i].GetQuantity());
                file.WriteLine("---");
            }
        }
    }

    static void LoadPantry() {
        List<Ingredient> ingredients = new List<Ingredient>();

        if (File.Exists("pantry.txt")) {
            string[] lines = File.ReadAllLines("pantry.txt");
            int i = 0;
            while (i + 3 <= lines.Length) {
                if (lines[i] == "---") { i++; continue; }

                string type = lines[i];
                string name = lines[i + 1];
                string quantity = lines[i + 2];
                Ingredient loaded = null;

                if (type == "DryGood") {
                    loaded = new DryGood(name, quantity);
                } else if (type == "Produce") {
                    loaded = new Produce(name, quantity, "Unknown");
                } else if (type == "Dairy") {
                    loaded = new Dairy(name, quantity);
                } else if (type == "Spice") {
                    loaded = new Spice(name, quantity, false);
                }

                if (loaded != null) ingredients.Add(loaded);
                i += 4;
            }
        }

        Pantry.SetIngredients(ingredients);

        List<FoodItem> foodItems = new List<FoodItem>();
        if (File.Exists("fooditems.txt")) {
            string[] lines = File.ReadAllLines("fooditems.txt");
            int i = 0;
            while (i + 3 <= lines.Length) {
                if (lines[i] == "---") { i++; continue; }
                foodItems.Add(new FoodItem(lines[i], lines[i + 1], lines[i + 2]));
                i += 4;
            }
        }

        Pantry.SetFoodItems(foodItems);
    }

    static void SaveRecipes() {
        using (StreamWriter file = new StreamWriter("recipes.txt")) {
            List<Recipe> recipes = RecipeList.GetAllRecipes();
            for (int i = 0; i < recipes.Count; i++) {
                file.WriteLine(recipes[i].GetName());
                file.WriteLine(recipes[i].GetDescription());
                List<string> ings = recipes[i].GetIngredients();
                file.WriteLine(ings.Count);
                for (int j = 0; j < ings.Count; j++) {
                    file.WriteLine(ings[j]);
                }
                file.WriteLine("---");
            }
        }
    }

    static void LoadRecipes() {
        List<Recipe> recipes = new List<Recipe>();

        if (File.Exists("recipes.txt")) {
            string[] lines = File.ReadAllLines("recipes.txt");
            int i = 0;
            while (i < lines.Length) {
                if (lines[i] == "---") { i++; continue; }

                string name = lines[i];
                string description = lines[i + 1];
                int count = int.Parse(lines[i + 2]);
                List<string> ings = new List<string>();
                for (int j = 0; j < count; j++) {
                    ings.Add(lines[i + 3 + j]);
                }
                recipes.Add(new Recipe(name, ings, description));
                i += 3 + count + 1;
            }
        }

        RecipeList.SetRecipes(recipes);
    }

    static void SaveGroceryList() {
        using (StreamWriter file = new StreamWriter("grocerylist.txt")) {
            List<string> items = GroceryList.GetItems();
            for (int i = 0; i < items.Count; i++) {
                file.WriteLine(items[i]);
            }
        }
    }

    static void LoadGroceryList() {
        List<string> items = new List<string>();
        if (File.Exists("grocerylist.txt")) {
            string[] lines = File.ReadAllLines("grocerylist.txt");
            for (int i = 0; i < lines.Length; i++) {
                if (lines[i] != "") items.Add(lines[i]);
            }
        }
        GroceryList.SetItems(items);
    }

    static void SaveSchedule() {
        string[,] schedule = Schedule.GetSchedule();
        using (StreamWriter file = new StreamWriter("schedule.txt")) {
            for (int d = 0; d < 7; d++) {
                for (int m = 0; m < 4; m++) {
                    string entry = schedule[d, m];
                    if (entry == null) entry = "";
                    file.WriteLine(entry);
                }
            }
        }
    }

    static void LoadSchedule() {
        string[,] schedule = new string[7, 4];
        if (File.Exists("schedule.txt")) {
            string[] lines = File.ReadAllLines("schedule.txt");
            int index = 0;
            for (int d = 0; d < 7; d++) {
                for (int m = 0; m < 4; m++) {
                    if (index < lines.Length) {
                        schedule[d, m] = lines[index];
                        index++;
                    }
                }
            }
        }
        Schedule.SetSchedule(schedule);
    }
}