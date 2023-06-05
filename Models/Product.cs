using System;
using System.Collections.Generic;

namespace EmergiaStoreMVC.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Detail { get; set; }

    public string? Image { get; set; }

    public int? IdCategory { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<ProductCycle> ProductCycles { get; set; } = new List<ProductCycle>();
}
