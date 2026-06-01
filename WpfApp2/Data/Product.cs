using System;
using System.Collections.Generic;

namespace WpfApp2.Data;

public partial class Product
{
    public string ProductsId { get; set; } = null!;

    public int? ProductTypeId { get; set; }

    public int? UnitId { get; set; }

    public decimal? Price { get; set; }

    public int? ImportId { get; set; }

    public int? CreaterId { get; set; }

    public int? CategoryId { get; set; }

    public int? Sale { get; set; }

    public int? Quantity { get; set; }

    public string? Info { get; set; }

    public string? Image { get; set; }

    public string ImageFullPath => !string.IsNullOrWhiteSpace(Image) ? $"Images/{Image}" : "Images/picture.png";
    public virtual Category? Category { get; set; }

    public virtual Creater? Creater { get; set; }

    public virtual ICollection<DetailsOrder> DetailsOrders { get; set; } = new List<DetailsOrder>();

    public virtual Import? Import { get; set; }

    public virtual ProductType? ProductType { get; set; }

    public virtual Unit? Unit { get; set; }
}
