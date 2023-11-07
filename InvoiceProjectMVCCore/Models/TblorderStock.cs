using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class TblorderStock
{
    public int OrderStockId { get; set; }

    public string? OderDate { get; set; }

    public int? UserId { get; set; }

    public int? VenderId { get; set; }

    public int? Flag { get; set; }

    public virtual ICollection<TblorderStockProduct> TblorderStockProducts { get; set; } = new List<TblorderStockProduct>();

    public virtual Tbluser? User { get; set; }

    public virtual Tblvender? Vender { get; set; }
}
