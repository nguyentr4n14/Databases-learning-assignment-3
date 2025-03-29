using System.ComponentModel.DataAnnotations;

namespace WebStore.Entities
{
    public class Store
    {
        public int StoreId { get; set; }

        [Required, MaxLength(100)]
        public string StoreName { get; set; } = null!;

        [MaxLength(20)]
        public string? Phone { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(100)]
        public string? Street { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }
        [MaxLength(20)]
        public string? PostalCode { get; set; }
        [MaxLength(50)]
        public string? Country { get; set; }

        // Navigation
        public ICollection<Staff>? StaffMembers { get; set; }
        public ICollection<Stocks>? Stocks { get; set; }
    }
}
