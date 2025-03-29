using System.ComponentModel.DataAnnotations;

namespace WebStore.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }

        [MaxLength(100)]
        public string? Street { get; set; }

        [MaxLength(50)]
        public string? City { get; set; }

        [MaxLength(50)]
        public string? State { get; set; }

        [MaxLength(20)]
        public string? PostalCode { get; set; }

        [MaxLength(50)]
        public string? Country { get; set; }

        [MaxLength(20)]
        public string? AddressType { get; set; }

        // Navigation
        public Customer? Customer { get; set; }
    }
}