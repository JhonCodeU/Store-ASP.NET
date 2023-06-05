using System;
using System.Collections.Generic;

namespace EmergiaStoreMVC.Models;

public partial class Cycle
{
    public int IdCycle { get; set; }

    public int? Number { get; set; }

    public int? Year { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ICollection<ProductCycle> ProductCycles { get; set; } = new List<ProductCycle>();
}
