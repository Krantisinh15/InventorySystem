using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class TblinvoiceProduct
{
    public int InvoiceProductId { get; set; }

    public int? InvoiceId { get; set; }

    public int? ProductId { get; set; }

    public double? PurchaseQuantity { get; set; }

    public int? Flag { get; set; }

    public virtual TblcustomerInvoice? Invoice { get; set; }

    public virtual Tblproduct? Product { get; set; }
}
