using Microsoft.CodeAnalysis;

namespace task_5_codefirst.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string? Description { get; set; }

        public ICollection<Product> Products { get; set; }
            = new List<Product>();
    }
}