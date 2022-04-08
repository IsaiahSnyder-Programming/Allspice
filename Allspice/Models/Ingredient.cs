namespace Allspice.Models
{
    public class Ingredient
    {
        public int? Id { get; set; }
        public string creatorId { get; set; }
        public int recipeId { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }

        // virtuals
        public Account? Creator { get; set; }
    }
}