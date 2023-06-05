using System;
using System.Collections.Generic;

namespace EmergiaStoreMVC.Models;

public partial class Salesperson
{
    public int IdSalesperson { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Facebook { get; set; }

    public string? Instagram { get; set; }

    public string? Twitter { get; set; }

    public string? Image { get; set; }

    public string? ConditionIf { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
