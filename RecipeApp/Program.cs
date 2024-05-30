using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Recipe Manager");
                Console.WriteLine("1. Create a new recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Select and display a recipe");
                Console.WriteLine("4. Scale a recipe");
                Console.WriteLine("5. Reset ingredient quantities");
                Console.WriteLine("6. Clear all recipes");
                Console.WriteLine("7. Exit");

                // Get user choice
                int choice = GetIntInput("Enter your choice: ");

                switch (choice)
                {
                    case 1:
                        recipes.Add(CreateRecipe());
                        break;
                    case 2:
                        DisplayAllRecipes(recipes);
                        break;
                    case 3:
                        DisplaySelectedRecipe(recipes);
                        break;
                    case 4:
                        ScaleRecipe(recipes);
                        break;
                    case 5:
                        ResetQuantities(recipes);
                        break;
                    case 6:
                        recipes.Clear();
                        Console.WriteLine("All recipes cleared.");
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Error, please enter a valid choice.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        // Function to create a new recipe
        static Recipe CreateRecipe()
        {
            Console.Write("Enter recipe name: ");
            string name = Console.ReadLine();

            int numIngredients = GetIntInput("Enter the number of ingredients: ");
            int numSteps = GetIntInput("Enter the number of steps: ");

            Recipe recipe = new Recipe(name);

            // Add ingredients to the recipe
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"\nIngredient {i + 1}:");
                Console.Write("Name: ");
                string ingredientName = Console.ReadLine();
                double quantity = GetDoubleInput("Quantity: ");
                Console.Write("Unit: ");
                string unit = Console.ReadLine();
                int calories = GetIntInput("Calories: ");
                Console.Write("Food Group: ");
                string foodGroup = Console.ReadLine();

                recipe.AddIngredient(new Ingredient(ingredientName, quantity, unit, calories, foodGroup));
            }

            // Add steps to the recipe
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"\nStep {i + 1}: ");
                string description = Console.ReadLine();
                recipe.AddStep(new Step(description));
            }

            // Subscribe to the event to notify when calories exceed 300
            recipe.RecipeCaloriesExceeded += RecipeCaloriesExceededHandler;

            return recipe;
        }

        // Handler for the RecipeCaloriesExceeded event
        static void RecipeCaloriesExceededHandler(string recipeName)
        {
            Console.WriteLine($"\nWarning: The total calories in the recipe '{recipeName}' exceed 300 calories!");
        }

        // Function to display all recipes
        static void DisplayAllRecipes(List<Recipe> recipes)
        {
            Console.WriteLine("\nAll Recipes:");
            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine(recipe.Name);
            }
        }

        // Function to display a selected recipe
        static void DisplaySelectedRecipe(List<Recipe> recipes)
        {
            Console.Write("Enter the name of the recipe to display: ");
            string name = Console.ReadLine();
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (recipe != null)
            {
                recipe.DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Function to scale a recipe
        static void ScaleRecipe(List<Recipe> recipes)
        {
            Console.Write("Enter the name of the recipe to scale: ");
            string name = Console.ReadLine();
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (recipe != null)
            {
                double factor = GetDoubleInput("Enter scaling factor (0.5, 2, or 3): ");
                recipe.ScaleRecipe(factor);
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Function to reset ingredient quantities in a recipe
        static void ResetQuantities(List<Recipe> recipes)
        {
            Console.Write("Enter the name of the recipe to reset: ");
            string name = Console.ReadLine();
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (recipe != null)
            {
                recipe.ResetQuantities();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Helper function to get integer input from the user
        static int GetIntInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    return value;
                }
                Console.WriteLine("Error. Please enter a valid number.");
            }
        }

        // Helper function to get double input from the user
        static double GetDoubleInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (double.TryParse(input, out double value))
                {
                    return value;
                }
                Console.WriteLine("Error. Please enter a valid number.");
            }
        }
    }
}

