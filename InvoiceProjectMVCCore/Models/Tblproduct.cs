using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class Tblproduct
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? UnitId { get; set; }

    public double? SellingRate { get; set; }

    public double? Tax { get; set; }

    public int? Flag { get; set; }

    public int? UserId { get; set; }

    public int? SubcategoryId { get; set; }

    public virtual Tblsubcategory? Subcategory { get; set; }

    public virtual ICollection<TblinvoiceProduct> TblinvoiceProducts { get; set; } = new List<TblinvoiceProduct>();

    public virtual ICollection<TblorderStockProduct> TblorderStockProducts { get; set; } = new List<TblorderStockProduct>();

    public virtual ICollection<TblrecivedStockProduct> TblrecivedStockProducts { get; set; } = new List<TblrecivedStockProduct>();

    public virtual Tblunit? Unit { get; set; }

    public virtual Tbluser? User { get; set; }
}
