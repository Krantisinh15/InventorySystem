using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class InvoicePayment
{
    public int PaymentId { get; set; }

    public string? PaymentDate { get; set; }

    public int? UserId { get; set; }

    public int? InvoiceId { get; set; }

    public double? PaymentAmount { get; set; }

    public string? PaymentMode { get; set; }

    public string? PaymentDescription { get; set; }

    public virtual TblcustomerInvoice? Invoice { get; set; }

    public virtual Tbluser? User { get; set; }
}
