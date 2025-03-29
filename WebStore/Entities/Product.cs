using System.ComponentModel.DataAnnotations;

namespace WebStore.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required, MaxLength(100)]
        public string ProductName { get; set; } = null!;

        [MaxLength(255)]
        public string? Description { get; set; }

        public decimal? Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public ICollection<ProductCategory>? ProductCategories { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
        public ICollection<Stocks>? Stocks { get; set; }
    }
}
