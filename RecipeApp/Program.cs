using System;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize currentRecipe to null, it will hold the currently active recipe
            Recipe currentRecipe = null;

            // Display main menu and process user input.
            while (true)
            {
                Console.WriteLine("\nRecipe Manager");
                Console.WriteLine("1. Create a new recipe");
                Console.WriteLine("2. Display Existing recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear recipe");
                Console.WriteLine("6. Exit");

                // Get user choice
                int choice = GetIntInput("Enter your choice: ");

                switch (choice)
                {
                    case 1:
                        // Create a new recipe and assign it to currentRecipe
                        currentRecipe = CreateRecipe();
                        break;
                    case 2:
                        // Display the existing recipe if available
                        if (currentRecipe == null)
                        {
                            Console.WriteLine("No recipe created yet.");
                        }
                        else
                        {
                            currentRecipe.DisplayRecipe();
                        }
                        break;
                    case 3:
                        // Scale the existing recipe by a factor provided by the user
                        if (currentRecipe == null)
                        {
                            Console.WriteLine("No recipe to scale.");
                        }
                        else
                        {
                            double factor = GetDoubleInput("Enter scaling factor (0.5, 2, or 3): ");
                            currentRecipe.ScaleRecipe(factor);
                        }
                        break;
                    case 4:
                        // Reset quantities of the existing recipe
                        if (currentRecipe == null)
                        {
                            Console.WriteLine("No recipe to reset.");
                        }
                        else
                        {
                            currentRecipe.ResetQuantities();
                        }
                        break;
                    case 5:
                        // Clear the currently active recipe
                        currentRecipe = null;
                        Console.WriteLine("Recipe cleared.");
                        break;
                    case 6:
                        // Exit the program
                        return;
                    default:
                        // Handle invalid input
                        Console.WriteLine(" Error please enter a valid choice.");
                        break;
                }
            }
        }

        // Create a new recipe by gathering details from the user
        static Recipe CreateRecipe()
        {
            Console.Write("Please enter recipe name: ");
            string name = Console.ReadLine();

            int numIngredients = GetIntInput("Enter the number of ingredients: ");
            int numSteps = GetIntInput("Enter the number of steps: ");

            // Create a new Recipe object
            Recipe recipe = new Recipe(name, numIngredients, numSteps);

            // Gather details for each ingredient
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}:");
                Console.Write("Name: ");
                string ingredientName = Console.ReadLine();
                double quantity = GetDoubleInput("Quantity: ");
                Console.Write("Unit: ");
                string unit = Console.ReadLine();

                // Create an Ingredient object and add it to the recipe
                recipe.Ingredients[i] = new Ingredient { Name = ingredientName, Quantity = quantity, Unit = unit };
            }

            // Gather details for each step
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Step {i + 1}: ");
                string description = Console.ReadLine();
                // Create a Step object and add it to the recipe
                recipe.Steps[i] = new Step { Description = description };
            }

            return recipe;
        }

        // Get integer input from the user with error handling
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
                Console.WriteLine("Error . Please enter a valid number.");
            }
        }

        // Get double input from the user with error handling
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
                Console.WriteLine("Error. Please enter a number.");
            }
        }
    }
}

