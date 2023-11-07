using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class Tblcategory
{
    public int CategoryId { get; set; }

    public string? Category { get; set; }

    public int? UserId { get; set; }

    public int? Flag { get; set; }

    public virtual ICollection<Tblsubcategory> Tblsubcategories { get; set; } = new List<Tblsubcategory>();

    public virtual Tbluser? User { get; set; }
}
