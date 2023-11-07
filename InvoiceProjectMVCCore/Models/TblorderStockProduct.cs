using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class TblorderStockProduct
{
    public int OrderStockProductId { get; set; }

    public int? OderStockId { get; set; }

    public int? ProductId { get; set; }

    public int? OderProductQuantity { get; set; }

    public int? Flag { get; set; }

    public virtual TblorderStock? OderStock { get; set; }

    public virtual Tblproduct? Product { get; set; }
}
