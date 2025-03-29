namespace WebStore.Entities
{
    public class Stocks
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }

        public int QuantityInStock { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public Store? Store { get; set; }
        public Product? Product { get; set; }
    }
}
