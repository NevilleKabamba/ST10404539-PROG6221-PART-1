
## How to Compile and Run the RecipeAppWPF
RecipeApp is a console application designed for managing recipes. It allows users to create, display, scale, reset quantities, and clear recipes with ease. The application supports an unlimited number of recipes, allows users to name them, and organizes them alphabetically. Additionally, users can enter calorie information and food groups for each ingredient, and the application will notify the user if the total calories exceed a specified limit.

## Features

- **Create New Recipes:** Users can enter an unlimited number of recipes, each with a unique name.
- **Ingredient Details:** For each ingredient, users can enter the quantity, unit, calories, and food group.
- **Recipe Display:** Display all recipes in alphabetical order and select a specific recipe to view its details.
- **Scale Recipes:** Scale the quantities of ingredients in a recipe by a specified factor (e.g., 0.5, 2, 3).
- **Reset Quantities:** Reset the quantities of all ingredients in a recipe to their original values.
- **Calorie Calculation:** Calculate and display the total calories for a recipe.
- **Calorie Notification:** Notify the user if the total calories of a recipe exceed 300.
- **Clear Recipes:** Clear all recipes from the list.
- **Event Handling:** Use delegates to notify the user when a recipe exceeds 300 calories.

### 1. Install Visual Studio

- Download and install Visual Studio from the official [Microsoft Visual Studio website](https://visualstudio.microsoft.com/).
- During the installation, include the "Desktop development with C++" and ".NET desktop development" workloads.

### 2. Clone the Repository

- Clone the repository containing the source code for the `RecipeAppWPF` application to your local machine using Git:
  ```sh
  git clone <repository-url>
  ```
- Navigate to the project directory:
  ```sh
  cd RecipeAppWPF
  ```

### 3. Open the Solution

- Open Visual Studio.
- Select `File -> Open -> Project/Solution`.
- Navigate to the `RecipeAppWPF` directory and select `RecipeAppWPF.sln`.

### 4. Build the Solution

- In Visual Studio, go to `Build -> Build Solution` or press `Ctrl+Shift+B`.
- Ensure there are no errors in the build output.

### 5. Run the Application

- Set `MainWindow.xaml` as the startup object.
- Press `F5` or go to `Debug -> Start Debugging` to run the application.

## How To Use

### Create a New Recipe

1. Select option 1 from the main menu.
2. Enter the recipe name, number of ingredients, and number of steps.
3. For each ingredient, enter the name, quantity, unit, calories, and food group.
4. For each step, enter the description.

### Display All Recipes

1. Select option 2 from the main menu to view a list of all recipes in alphabetical order.

### Select and Display a Recipe

1. Select option 3 from the main menu.
2. Enter the name of the recipe you wish to display.
3. The recipe details, including ingredients and steps, will be displayed.

### Scale a Recipe

1. Select option 4 from the main menu.
2. Enter the name of the recipe you wish to scale.
3. Enter the scaling factor (e.g., 0.5, 2, 3).
4. The ingredient quantities will be scaled accordingly.

### Reset Ingredient Quantities

1. Select option 5 from the main menu.
2. Enter the name of the recipe you wish to reset.
3. The ingredient quantities will be reset to their original values.

### Clear All Recipes

1. Select option 6 from the main menu to clear all recipes.

### Exit the Application

1. Select option 7 from the main menu to exit the application.

## GitHub Link

[RecipeApp GitHub Repository](https://github.com/NevilleKabamba/ST10404539-PROG6221-PART-1.git)
