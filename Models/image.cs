using System;
using System.Collections.Generic;

namespace server.Models;

public partial class image
{
    public int image_id { get; set; }

    public string image_url { get; set; } = null!;

    public int product_id { get; set; }

    public virtual product product { get; set; } = null!;
}
