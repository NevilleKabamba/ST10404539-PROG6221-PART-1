namespace RecipeApp
{
    public class Step
    {
        public string Description { get; set; } // Description of the step

        public Step(string description)
        {
            Description = description;
        }
    }
}
