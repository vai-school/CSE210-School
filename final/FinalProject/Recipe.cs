using System;
using System.Collections.Generic;

class Recipe {
    private string name;
    private List<string> ingredients;
    private string description;

    public Recipe(string name, List<string> ingredients, string description) {
        this.name = name;
        this.ingredients = ingredients;
        this.description = description;
    }

    public void Display() {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Ingredients:");
        for (int i = 0; i < ingredients.Count; i++) {
            Console.WriteLine("  - " + ingredients[i]);
        }
        Console.WriteLine("Description: " + description);
        Console.WriteLine();
    }

    public string GetName() {
        return name;
    }

    public List<string> GetIngredients() {
        return ingredients;
    }

    public string GetDescription() {
        return description;
    }

    public void SetName(string newName) {
        name = newName;
    }

    public void SetIngredients(List<string> newIngredients) {
        ingredients = newIngredients;
    }

    public void SetDescription(string newDescription) {
        description = newDescription;
    }
}

class RecipeList {
    private static List<Recipe> recipes = new List<Recipe>();

    public static void RecipeMenu() {
        int choice = 0;
        while (choice != 6) {
            Console.WriteLine("=== Recipes ===");
            Console.WriteLine("1. Add Recipe");
            Console.WriteLine("2. View All Recipes");
            Console.WriteLine("3. View Recipe Details");
            Console.WriteLine("4. Edit Recipe");
            Console.WriteLine("5. Remove Recipe");
            Console.WriteLine("6. Go Back");
            Console.Write("Choice: ");

            if (int.TryParse(Console.ReadLine(), out choice)) {
                if (choice == 1) {
                    AddRecipe();
                } else if (choice == 2) {
                    ShowAllRecipes();
                } else if (choice == 3) {
                    ViewRecipeDetails();
                } else if (choice == 4) {
                    EditRecipe();
                } else if (choice == 5) {
                    RemoveRecipe();
                } else if (choice == 6) {
                    Console.WriteLine("Going back...\n");
                } else {
                    Console.WriteLine("Please enter a number between 1 and 6.\n");
                }
            } else {
                Console.WriteLine("Please enter a number.\n");
            }
        }
    }

    public static void AddRecipe() {
        Console.Write("Recipe name: ");
        string name = Console.ReadLine();

        List<string> ingredients = new List<string>();
        Console.WriteLine("Enter ingredients one at a time. Type 'done' when finished.");
        Console.WriteLine("Note: ingredient names are case sensitive and must match your pantry.");

        while (true) {
            Console.Write("Ingredient: ");
            string ing = Console.ReadLine();
            if (ing.ToLower() == "done") break;

            if (Pantry.HasIngredient(ing)) {
                ingredients.Add(ing);
                Console.WriteLine(ing + " added.");
            } else {
                Console.WriteLine("'" + ing + "' not found in pantry. Add it to the pantry first.");
            }
        }

        Console.Write("Description: ");
        string description = Console.ReadLine();

        recipes.Add(new Recipe(name, ingredients, description));
        Console.WriteLine("Recipe added!\n");
    }

    public static void ShowAllRecipes() {
        if (recipes.Count == 0) {
            Console.WriteLine("No recipes yet.\n");
            return;
        }
        Console.WriteLine("\n=== All Recipes ===");
        for (int i = 0; i < recipes.Count; i++) {
            Console.WriteLine((i + 1) + ". " + recipes[i].GetName());
        }
        Console.WriteLine();
    }

    public static void ViewRecipeDetails() {
        if (recipes.Count == 0) {
            Console.WriteLine("No recipes yet.\n");
            return;
        }
        ShowAllRecipes();
        Console.Write("Which recipe? (number): ");
        if (int.TryParse(Console.ReadLine(), out int index)) {
            if (index >= 1 && index <= recipes.Count) {
                recipes[index - 1].Display();
            } else {
                Console.WriteLine("Invalid number.\n");
            }
        } else {
            Console.WriteLine("Please enter a number.\n");
        }
    }

    public static void EditRecipe() {
        if (recipes.Count == 0) {
            Console.WriteLine("No recipes yet.\n");
            return;
        }
        ShowAllRecipes();
        Console.Write("Which recipe to edit? (number): ");
        if (int.TryParse(Console.ReadLine(), out int index)) {
            if (index >= 1 && index <= recipes.Count) {
                Recipe recipe = recipes[index - 1];
                Console.WriteLine("1. Edit Name");
                Console.WriteLine("2. Edit Ingredients");
                Console.WriteLine("3. Edit Description");
                Console.Write("Choice: ");

                if (int.TryParse(Console.ReadLine(), out int field)) {
                    if (field == 1) {
                        Console.Write("New name: ");
                        recipe.SetName(Console.ReadLine());
                        Console.WriteLine("Name updated!\n");
                    } else if (field == 2) {
                        List<string> newIngredients = new List<string>();
                        Console.WriteLine("Enter new ingredients one at a time. Type 'done' when finished.");
                        while (true) {
                            Console.Write("Ingredient: ");
                            string ing = Console.ReadLine();
                            if (ing.ToLower() == "done") break;
                            if (Pantry.HasIngredient(ing)) {
                                newIngredients.Add(ing);
                                Console.WriteLine(ing + " added.");
                            } else {
                                Console.WriteLine("'" + ing + "' not found in pantry.");
                            }
                        }
                        recipe.SetIngredients(newIngredients);
                        Console.WriteLine("Ingredients updated!\n");
                    } else if (field == 3) {
                        Console.Write("New description: ");
                        recipe.SetDescription(Console.ReadLine());
                        Console.WriteLine("Description updated!\n");
                    } else {
                        Console.WriteLine("Invalid choice.\n");
                    }
                } else {
                    Console.WriteLine("Please enter a number.\n");
                }
            } else {
                Console.WriteLine("Invalid number.\n");
            }
        } else {
            Console.WriteLine("Please enter a number.\n");
        }
    }

    public static void RemoveRecipe() {
        if (recipes.Count == 0) {
            Console.WriteLine("No recipes yet.\n");
            return;
        }
        ShowAllRecipes();
        Console.Write("Which recipe to remove? (number): ");
        if (int.TryParse(Console.ReadLine(), out int index)) {
            if (index >= 1 && index <= recipes.Count) {
                string name = recipes[index - 1].GetName();
                recipes.RemoveAt(index - 1);
                Console.WriteLine(name + " removed!\n");
            } else {
                Console.WriteLine("Invalid number.\n");
            }
        } else {
            Console.WriteLine("Please enter a number.\n");
        }
    }

    public static string RandomRecipe() {
        if (recipes.Count == 0) {
            return "No recipes yet.";
        }
        Random random = new Random();
        int index = random.Next(recipes.Count);
        return recipes[index].GetName();
    }

    public static bool HasRecipe(string recipeName) {
        for (int i = 0; i < recipes.Count; i++) {
            if (recipes[i].GetName() == recipeName) {
                return true;
            }
        }
        return false;
    }

    public static List<Recipe> GetAllRecipes() {
        return recipes;
    }

    public static void SetRecipes(List<Recipe> loaded) {
        recipes = loaded;
    }
}