using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeApp;

namespace RecipeAppTests
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void TestTotalCalories()
        {
            var recipe = new Recipe("Test Recipe");

            recipe.AddIngredient(new Ingredient("Sugar", 100, "grams", 387, "Sweets"));
            recipe.AddIngredient(new Ingredient("Butter", 50, "grams", 360, "Dairy"));

            Assert.AreEqual(747, recipe.GetTotalCalories());
        }

        [TestMethod]
        public void TestCaloriesExceededEvent()
        {
            var recipe = new Recipe("Test Recipe");
            bool eventTriggered = false;

            recipe.RecipeCaloriesExceeded += (name) => eventTriggered = true;

            recipe.AddIngredient(new Ingredient("Sugar", 100, "grams", 387, "Sweets"));

            Assert.IsTrue(eventTriggered);
        }
    }
}
