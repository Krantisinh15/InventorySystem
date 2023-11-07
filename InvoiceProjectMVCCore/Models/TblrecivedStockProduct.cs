using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class TblrecivedStockProduct
{
    public int RecivedStockProductsId { get; set; }

    public int? RecivedStockId { get; set; }

    public int? ProductId { get; set; }

    public double? RecivedProductQuantity { get; set; }

    public double? RecivedProductRate { get; set; }

    public int? UserId { get; set; }

    public virtual Tblproduct? Product { get; set; }

    public virtual TblrecivedStock? RecivedStock { get; set; }

    public virtual Tbluser? User { get; set; }
}
