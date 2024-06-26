using System;
using System.Collections.Generic;

namespace RecipeAppWPF
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        private readonly Action<string> _notifyHighCalories;

        public Recipe(string name, Action<string> notifyHighCalories)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
            _notifyHighCalories = notifyHighCalories;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            CheckCalories();
        }

        public void AddStep(Step step)
        {
            Steps.Add(step);
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

        public double TotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        private void CheckCalories()
        {
            if (TotalCalories() > 300)
            {
                _notifyHighCalories?.Invoke($"The total calories for the recipe '{Name}' exceeds 300!");
            }
        }
    }
}

