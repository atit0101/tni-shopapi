using System;
using System.Collections.Generic;

namespace server.Models;

public partial class category
{
    public int category_id { get; set; }

    public string category_name { get; set; } = null!;

    public virtual ICollection<product> products { get; set; } = new List<product>();
}
