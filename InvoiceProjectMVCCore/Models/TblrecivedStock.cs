using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class TblrecivedStock
{
    public int RecivedStockId { get; set; }

    public int? VenderId { get; set; }

    public string? RecivedDate { get; set; }

    public int? UserId { get; set; }

    public int? Flag { get; set; }

    public virtual ICollection<TblrecivedStockProduct> TblrecivedStockProducts { get; set; } = new List<TblrecivedStockProduct>();

    public virtual Tbluser? User { get; set; }

    public virtual Tblvender? Vender { get; set; }
}
