using System;
using System.Collections.Generic;

namespace WpfApp2.Data;

public partial class ProductType
{
    public int ProductTypeId { get; set; }

    public string? ProductName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
