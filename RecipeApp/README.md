RecipeApp

RecipeApp is a console application designed for managing recipes. It allows users to create, display, scale, reset quantities, and clear recipes with ease. The application supports an unlimited number of recipes, allows users to name them, and organizes them alphabetically. Additionally, users can enter calorie information and food groups for each ingredient, and the application will notify the user if the total calories exceed a specified limit.

## Features

Create New Recipes: Users can enter an unlimited number of recipes, each with a unique name.
Ingredient Details: For each ingredient, users can enter the quantity, unit, calories, and food group.
Recipe Display: Display all recipes in alphabetical order and select a specific recipe to view its details.
Scale Recipes: Scale the quantities of ingredients in a recipe by a specified factor (e.g., 0.5, 2, 3).
Reset Quantities: Reset the quantities of all ingredients in a recipe to their original values.
Calorie Calculation: Calculate and display the total calories for a recipe.
Calorie Notification: Notify the user if the total calories of a recipe exceed 300.
Clear Recipes: Clear all recipes from the list.
Event Handling: Use delegates to notify the user when a recipe exceeds 300 calories.
Installation

To install and run RecipeApp, follow these steps:

Clone the Repository: Clone the repository to your local machine using the following command:

sh
Copy code
git clone https://github.com/NevilleKabamba/ST10404539-PROG6221-PART-1.git
Open the Solution: Open the solution in an IDE such as Visual Studio or Visual Studio Code.

Build the Solution: Build the solution to ensure all dependencies are resolved.

Run the Application: Run the application and follow the prompts on the console to perform various operations.

How To Use

## Create a New Recipe:

Select option 1 from the main menu.
Enter the recipe name, number of ingredients, and number of steps.
For each ingredient, enter the name, quantity, unit, calories, and food group.
For each step, enter the description.
Display All Recipes:

Select option 2 from the main menu to view a list of all recipes in alphabetical order.
Select and Display a Recipe:

Select option 3 from the main menu.
Enter the name of the recipe you wish to display.
The recipe details, including ingredients and steps, will be displayed.
Scale a Recipe:

Select option 4 from the main menu.
Enter the name of the recipe you wish to scale.
Enter the scaling factor (e.g., 0.5, 2, 3).
The ingredient quantities will be scaled accordingly.
Reset Ingredient Quantities:

Select option 5 from the main menu.
Enter the name of the recipe you wish to reset.
The ingredient quantities will be reset to their original values.
Clear All Recipes:

Select option 6 from the main menu to clear all recipes.
Exit the Application:

Select option 7 from the main menu to exit the application.

## Project Structure

RecipeApp: Contains the main application code.
Program.cs: Entry point for the application, includes the main menu loop and user input handling.
Recipe.cs: Defines the Recipe class representing a recipe, including methods for displaying, scaling, and resetting quantities.
Ingredient.cs: Defines the Ingredient class representing an ingredient in a recipe.
Step.cs: Defines the Step class representing a step in a recipe.
 
 ## Github Link 
   https://github.com/NevilleKabamba/ST10404539-PROG6221-PART-1.git
    ST10404539
