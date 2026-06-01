using System;
using System.Collections.Generic;

namespace WpfApp2.Data;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryType { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
