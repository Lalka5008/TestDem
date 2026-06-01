using System;
using System.Collections.Generic;

namespace WpfApp2.Data;

public partial class Import
{
    public int ImportId { get; set; }

    public string? ImportName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
