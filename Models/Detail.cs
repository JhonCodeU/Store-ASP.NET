using System;
using System.Collections.Generic;

namespace EmergiaStoreMVC.Models;

public partial class Detail
{
    public int IdDetail { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public int? IdProduct { get; set; }

    public int? IdCycle { get; set; }

    public int? IdInvoice { get; set; }

    public virtual ProductCycle? Id { get; set; }

    public virtual Invoice? IdInvoiceNavigation { get; set; }
}
