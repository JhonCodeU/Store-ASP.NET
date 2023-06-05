using System;
using System.Collections.Generic;

namespace EmergiaStoreMVC.Models;

public partial class ProductCycle
{
    public int IdProduct { get; set; }

    public decimal? Price { get; set; }

    public decimal? PromotionalPrice { get; set; }

    public decimal? SalesCommission { get; set; }

    public decimal? Cannon { get; set; }

    public int IdCycle { get; set; }

    public virtual ICollection<Detail> Details { get; set; } = new List<Detail>();

    public virtual Cycle IdCycleNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
