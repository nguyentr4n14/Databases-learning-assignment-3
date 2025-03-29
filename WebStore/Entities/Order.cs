using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        public DateTime? OrderDate { get; set; }

        [MaxLength(20)]
        public string? OrderStatus { get; set; }

        public int ShippingAddressId { get; set; }
        public int BillingAddressId { get; set; }

        // Navigation
        public Customer? Customer { get; set; }
        public Address? ShippingAddress { get; set; }
        public Address? BillingAddress { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
