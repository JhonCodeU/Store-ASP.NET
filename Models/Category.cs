﻿using System;
using System.Collections.Generic;

namespace EmergiaStoreMVC.Models;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? Name { get; set; }

    public string? Detail { get; set; }

    public int? ParentCategoryId { get; set; }

    public virtual ICollection<Category> InverseParentCategory { get; set; } = new List<Category>();

    public virtual Category? ParentCategory { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
