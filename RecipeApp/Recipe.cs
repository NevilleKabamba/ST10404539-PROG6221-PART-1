using System;
using System.Collections.Generic;

namespace RecipeApp
{
    public class Recipe
    {
        public string Name { get; set; } // Name of the recipe
        private List<Ingredient> Ingredients { get; set; } // List of ingredients
        private List<Step> Steps { get; set; } // List of steps

        // Event to notify when total calories exceed 300
        public event Action<string> RecipeCaloriesExceeded;

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        // Method to add an ingredient to the recipe
        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            if (GetTotalCalories() > 300)
            {
                RecipeCaloriesExceeded?.Invoke(Name);
            }
        }

        // Method to add a step to the recipe
        public void AddStep(Step step)
        {
            Steps.Add(step);
        }

        // Method to display the recipe details
        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name}");

            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }

            Console.WriteLine("\nSteps:");
            int stepNumber = 1;
            foreach (var step in Steps)
            {
                Console.WriteLine($"{stepNumber++}. {step.Description}");
            }

            Console.WriteLine($"\nTotal Calories: {GetTotalCalories()}");
        }

        // Method to scale the recipe ingredients by a factor
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        // Method to reset ingredient quantities to 1
        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = 1.0;
            }
        }

        // Method to get the total calories of the recipe
        public int GetTotalCalories()
        {
            int totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }
    }
}


