
using System;

namespace RecipeApp
{
    public class Recipe
    {
        public string Name { get; set; } // Name of the recipe
        public Ingredient[] Ingredients { get; set; } // Array to store ingredients
        public Step[] Steps { get; set; } // Array to store steps

        // Constructor to initialize the recipe with name, number of ingredients, and number of steps
        public Recipe(string name, int numIngredients, int numSteps)
        {
            Name = name;
            Ingredients = new Ingredient[numIngredients]; // Initialize ingredients array
            Steps = new Step[numSteps]; // Initialize steps array
        }

        // Display the recipe details including ingredients and steps
        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name}"); // Display recipe name

            // Display ingredients list
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
            }

            // Display steps list
            Console.WriteLine("\nSteps:");
            int stepNumber = 1;
            foreach (Step step in Steps)
            {
                Console.WriteLine($"{stepNumber++}. {step.Description}");
            }
        }

        // Scale the quantities of ingredients in the recipe by a given factor
        public void ScaleRecipe(double factor)
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity *= factor; // Multiply each ingredient quantity by the scaling factor
            }
        }

        // Reset the quantities of ingredients in the recipe to 1.0
        public void ResetQuantities()
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity = 1.0; // Reset each ingredient quantity to 1.0
            }
        }
    }
}
