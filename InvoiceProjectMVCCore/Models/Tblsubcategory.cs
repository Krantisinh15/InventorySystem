using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class Tblsubcategory
{
    public int SubcategoryId { get; set; }

    public string? Subcategory { get; set; }

    public int? CategoryId { get; set; }

    public int? UserId { get; set; }

    public int? Flag { get; set; }

    public virtual Tblcategory? Category { get; set; }

    public virtual ICollection<Tblproduct> Tblproducts { get; set; } = new List<Tblproduct>();

    public virtual Tbluser? User { get; set; }
}
