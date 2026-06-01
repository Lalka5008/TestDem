using System;
using System.Collections.Generic;

namespace WpfApp2.Data;

public partial class Pvz
{
    public int Pvzid { get; set; }

    public string? Pvzname { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
