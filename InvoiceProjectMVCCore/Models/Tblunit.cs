using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class Tblunit
{
    public int UnitId { get; set; }

    public string? UnitName { get; set; }

    public virtual ICollection<Tblproduct> Tblproducts { get; set; } = new List<Tblproduct>();
}
