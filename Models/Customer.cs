using System;
using System.Collections.Generic;

namespace EmergiaStoreMVC.Models;

public partial class Customer
{
    public int IdCustomer { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Instagram { get; set; }

    public string? Facebook { get; set; }

    public string? Twitter { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
