using System;
using System.Collections.Generic;

namespace server.Models;

public partial class product
{
    public int product_id { get; set; }

    public string product_name { get; set; } = null!;

    public float price { get; set; }

    public int category_id { get; set; }

    public string product_data { get; set; } = null!;

    public virtual category category { get; set; } = null!;

    public virtual ICollection<image> images { get; set; } = new List<image>();
}
