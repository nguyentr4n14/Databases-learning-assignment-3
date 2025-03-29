namespace WebStore.Entities
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        // Navigation
        public Category? Category { get; set; }
        public Product? Product { get; set; }
    }
}
