using System;
using System.Collections.Generic;

namespace WebStore.Entities;

public partial class Stock
{
    public int StoreId { get; set; }

    public int ProductId { get; set; }

    public int QuantityInStock { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
