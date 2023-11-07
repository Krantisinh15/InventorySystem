using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class TblcustomerInvoice
{
    public int InvoiceId { get; set; }

    public string? InvoiceDate { get; set; }

    public int? CustomerId { get; set; }

    public int? UserId { get; set; }

    public double? TotalAmount { get; set; }

    public int? Flag { get; set; }

    public virtual Tblcustomer? Customer { get; set; }

    public virtual ICollection<InvoicePayment> InvoicePayments { get; set; } = new List<InvoicePayment>();

    public virtual ICollection<TblinvoiceProduct> TblinvoiceProducts { get; set; } = new List<TblinvoiceProduct>();

    public virtual Tbluser? User { get; set; }
}
