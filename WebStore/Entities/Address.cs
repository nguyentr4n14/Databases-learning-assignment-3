using System;
using System.Collections.Generic;

namespace WebStore.Entities;

public partial class Address
{
    public int AddressId { get; set; }

    public int CustomerId { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? AddressType { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Order> OrderBillingAddresses { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderShippingAddresses { get; set; } = new List<Order>();
}
