using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RecipeAppWPF
{
    public partial class AddRecipeWindow : Window
    {
        private List<Recipe> recipes;
        private Recipe currentRecipe;

        // Constructor to initialize the AddRecipeWindow and set up the recipe list.
        public AddRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            currentRecipe = new Recipe("", null);
        }

        // Event handler for adding an ingredient.
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            string name = IngredientName.Text;
            if (double.TryParse(IngredientQuantity.Text, out double quantity) &&
                double.TryParse(IngredientCalories.Text, out double calories))
            {
                string unit = IngredientUnit.Text;
                string foodGroup = (IngredientFoodGroup.SelectedItem as ComboBoxItem)?.Content.ToString();

                var ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);
                currentRecipe.AddIngredient(ingredient);

                MessageBox.Show("Ingredient added.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearIngredientInputs();
            }
            else
            {
                MessageBox.Show("Please enter valid values for quantity and calories.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Event handler for saving the recipe.
        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            currentRecipe.Name = RecipeName.Text;
            recipes.Add(currentRecipe);
            MessageBox.Show("Recipe saved.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        // Clears the input fields for the ingredient.
        private void ClearIngredientInputs()
        {
            IngredientName.Text = "Ingredient Name";
            IngredientName.Foreground = Brushes.Gray;

            IngredientQuantity.Text = "Quantity";
            IngredientQuantity.Foreground = Brushes.Gray;

            IngredientUnit.Text = "Unit";
            IngredientUnit.Foreground = Brushes.Gray;

            IngredientCalories.Text = "Calories";
            IngredientCalories.Foreground = Brushes.Gray;

            IngredientFoodGroup.SelectedIndex = -1;
        }

        // Removes placeholder text when the TextBox gains focus.
        private void RemovePlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Foreground == Brushes.Gray)
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        // Adds placeholder text when the TextBox loses focus and is empty.
        private void AddPlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = Brushes.Gray;
                if (textBox == RecipeName) textBox.Text = "Recipe Name";
                else if (textBox == IngredientName) textBox.Text = "Ingredient Name";
                else if (textBox == IngredientQuantity) textBox.Text = "Quantity";
                else if (textBox == IngredientUnit) textBox.Text = "Unit";
                else if (textBox == IngredientCalories) textBox.Text = "Calories";
            }
        }
    }
}
