using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class Tblvender
{
    public int VenderId { get; set; }

    public string? VenderName { get; set; }

    public string? MobileNo { get; set; }

    public string? EmailAddress { get; set; }

    public int? UserId { get; set; }

    public int? Flag { get; set; }

    public virtual ICollection<TblorderStock> TblorderStocks { get; set; } = new List<TblorderStock>();

    public virtual ICollection<TblrecivedStock> TblrecivedStocks { get; set; } = new List<TblrecivedStock>();

    public virtual Tbluser? User { get; set; }
}
