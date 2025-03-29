using System.ComponentModel.DataAnnotations;

namespace WebStore.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required, MaxLength(100)]
        public string CategoryName { get; set; } = null!;

        public int? ParentCategoryId { get; set; }

        // Navigation
        public Category? ParentCategory { get; set; }
        public ICollection<Category>? SubCategories { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }
    }
}
