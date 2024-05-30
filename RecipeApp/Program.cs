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

            // Display main menu and process user input
            while (true)
            {
                Console.WriteLine("\nRecipe Manager");
                Console.WriteLine("1. Create a new recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Select and display a recipe");
                Console.WriteLine("4. Scale recipe");
                Console.WriteLine("5. Reset quantities");
                Console.WriteLine("6. Clear recipes");
                Console.WriteLine("7. Exit");

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
            }
        }

        static Recipe CreateRecipe()
        {
            Console.Write("Please enter recipe name: ");
            string name = Console.ReadLine();

            int numIngredients = GetIntInput("Enter the number of ingredients: ");
            int numSteps = GetIntInput("Enter the number of steps: ");

            Recipe recipe = new Recipe(name);

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}:");
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

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Step {i + 1}: ");
                string description = Console.ReadLine();
                recipe.AddStep(new Step(description));
            }

            return recipe;
        }

        static void DisplayAllRecipes(List<Recipe> recipes)
        {
            Console.WriteLine("\nAll Recipes:");
            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine(recipe.Name);
            }
        }

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

