using System.ComponentModel.DataAnnotations;

namespace WebStore.Entities
{
    public class Staff
    {
        public int StaffId { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Email { get; set; } = null!;

        [MaxLength(20)]
        public string? Phone { get; set; }

        public int StoreId { get; set; }

        // Navigation
        public Store? Store { get; set; }
    }
}
