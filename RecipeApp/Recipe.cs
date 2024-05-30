using System;
using System.Collections.Generic;

namespace RecipeApp
{
    public class Recipe
    {
        public string Name { get; set; }
        private List<Ingredient> Ingredients { get; set; }
        private List<Step> Steps { get; set; }

        public event Action<string> RecipeCaloriesExceeded;

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            if (GetTotalCalories() > 300)
            {
                RecipeCaloriesExceeded?.Invoke(Name);
            }
        }

        public void AddStep(Step step)
        {
            Steps.Add(step);
        }

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

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = 1.0;
            }
        }

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

