using System;
using System.Collections.Generic;

namespace WpfApp2.Data;

public partial class Order
{
    public int OrdersId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public DateOnly? DevileryDate { get; set; }

    public int? Pvzid { get; set; }

    public int? UsersId { get; set; }

    public int? Code { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<DetailsOrder> DetailsOrders { get; set; } = new List<DetailsOrder>();

    public virtual Pvz? Pvz { get; set; }

    public virtual Status? Status { get; set; }

    public virtual User? Users { get; set; }
}
