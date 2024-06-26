using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RecipeAppWPF
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes = new List<Recipe>();
        public event Action<string> NotifyHighCalories;

        // Constructor to initialize the MainWindow and set up the high-calorie notification.
        public MainWindow()
        {
            InitializeComponent();
            NotifyHighCalories += message => MessageBox.Show($"Notification: {message}", "High Calories", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        // Event handler for adding a recipe.
        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            var addRecipeWindow = new AddRecipeWindow(recipes);
            addRecipeWindow.ShowDialog();
        }

        // Event handler for displaying recipes
        private void DisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            DisplayRecipes();
        }

        // Event handler for scaling a recipe.
        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            var selectedRecipe = SelectRecipe();
            if (selectedRecipe != null)
            {
                double factor = GetDoubleInput("Enter scaling factor (0.5, 2, or 3): ");
                selectedRecipe.ScaleRecipe(factor);
                MessageBox.Show("Recipe scaled.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Event handler for resetting quantities of a recipe
        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            var selectedRecipe = SelectRecipe();
            if (selectedRecipe != null)
            {
                selectedRecipe.ResetQuantities();
                MessageBox.Show("Quantities reset.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Event handler for clearing a recipe
        private void ClearRecipe_Click(object sender, RoutedEventArgs e)
        {
            var selectedRecipe = SelectRecipe();
            if (selectedRecipe != null)
            {
                recipes.Remove(selectedRecipe);
                DisplayRecipes();
                MessageBox.Show("Recipe cleared.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Event handler for filtering recipes
        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            string ingredient = IngredientFilter.Text.ToLower();
            string foodGroup = (FoodGroupFilter.SelectedItem as ComboBoxItem)?.Content.ToString().ToLower();
            if (double.TryParse(CaloriesFilter.Text, out double maxCalories))
            {
                var filteredRecipes = recipes.Where(r =>
                    (string.IsNullOrEmpty(ingredient) || r.Ingredients.Any(i => i.Name.ToLower().Contains(ingredient))) &&
                    (string.IsNullOrEmpty(foodGroup) || r.Ingredients.Any(i => i.FoodGroup.ToLower() == foodGroup)) &&
                    (maxCalories == 0 || r.TotalCalories() <= maxCalories)).ToList();
                DisplayRecipes(filteredRecipes);
            }
            else
            {
                MessageBox.Show("Please enter a valid number for calories.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Displays the list of recipes
        private void DisplayRecipes(List<Recipe> recipesToDisplay = null)
        {
            RecipesList.Items.Clear();
            var recipesList = recipesToDisplay ?? recipes.OrderBy(r => r.Name).ToList();
            foreach (var recipe in recipesList)
            {
                RecipesList.Items.Add(recipe.Name);
            }
        }

        // Selects a recipe from the list
        private Recipe SelectRecipe()
        {
            if (!recipes.Any())
            {
                MessageBox.Show("No recipes available.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }

            if (RecipesList.SelectedItem != null)
            {
                string selectedRecipeName = RecipesList.SelectedItem.ToString();
                return recipes.FirstOrDefault(r => r.Name == selectedRecipeName);
            }
            else
            {
                MessageBox.Show("Please select a recipe from the list.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
        }

        // Gets a double input from the user
        private double GetDoubleInput(string message)
        {
            while (true)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox(message, "Input", "0");
                if (double.TryParse(input, out double value))
                {
                    return value;
                }
                MessageBox.Show("Error: Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Removes placeholder text when the TextBox gains focus
        private void RemovePlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Foreground == Brushes.Gray)
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        // Adds placeholder text when the TextBox loses focus and is empty
        private void AddPlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = Brushes.Gray;
                if (textBox == IngredientFilter) textBox.Text = "Ingredient";
                else if (textBox == CaloriesFilter) textBox.Text = "Max Calories";
            }
        }
    }
}
