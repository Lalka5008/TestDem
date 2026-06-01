using System;
using System.Collections.Generic;

namespace WpfApp2.Data;

public partial class Status
{
    public int StatusId { get; set; }

    public string? StatusType { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
