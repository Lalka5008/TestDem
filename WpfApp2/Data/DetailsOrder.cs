using System;
using System.Collections.Generic;

namespace WpfApp2.Data;

public partial class DetailsOrder
{
    public int DetailsOrdersId { get; set; }

    public int? OrdersId { get; set; }

    public string? ProductsId { get; set; }

    public int? Quantity { get; set; }

    public virtual Order? Orders { get; set; }

    public virtual Product? Products { get; set; }
}
