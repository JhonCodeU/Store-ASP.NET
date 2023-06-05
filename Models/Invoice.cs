using System;
using System.Collections.Generic;

namespace EmergiaStoreMVC.Models;

public partial class Invoice
{
    public int IdInvoice { get; set; }

    public DateTime? Date { get; set; }

    public int? IdCustomer { get; set; }

    public int? IdSalesperson { get; set; }

    public virtual ICollection<Detail> Details { get; set; } = new List<Detail>();

    public virtual Customer? IdCustomerNavigation { get; set; }

    public virtual Salesperson? IdSalespersonNavigation { get; set; }
}
