using System;
using System.Collections.Generic;

namespace WebStore.Entities;

public partial class Staff
{
    public int StaffId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public int StoreId { get; set; }

    public virtual Store Store { get; set; } = null!;
}
