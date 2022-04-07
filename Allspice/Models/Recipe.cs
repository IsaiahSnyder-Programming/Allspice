namespace Allspice.Models
{
    public class Recipe
    {
        public int? Id { get; set; }
        public string creatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string imgUrl { get; set; }
        public int AverageTime { get; set; }

        // virtuals
        public Account? Creator { get; set; }
    }
}