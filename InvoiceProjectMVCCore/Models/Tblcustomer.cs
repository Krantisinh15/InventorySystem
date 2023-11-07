using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class Tblcustomer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? MobileNo { get; set; }

    public string? EmailAddress { get; set; }

    public int? LocationId { get; set; }

    public int? UserId { get; set; }

    public int? Flag { get; set; }

    public virtual Tbllocation? Location { get; set; }

    public virtual ICollection<TblcustomerInvoice> TblcustomerInvoices { get; set; } = new List<TblcustomerInvoice>();

    public virtual Tbluser? User { get; set; }
}
