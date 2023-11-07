using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class Tbluser
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? MobileNumber { get; set; }

    public string? EmailAddress { get; set; }

    public string? UniqueCode { get; set; }

    public string? Password { get; set; }

    public int? LocationId { get; set; }

    public int? Flag { get; set; }

    public string? UserPhoto { get; set; }

    public virtual ICollection<InvoicePayment> InvoicePayments { get; set; } = new List<InvoicePayment>();

    public virtual Tbllocation? Location { get; set; }

    public virtual ICollection<Tblcategory> Tblcategories { get; set; } = new List<Tblcategory>();

    public virtual ICollection<TblcustomerInvoice> TblcustomerInvoices { get; set; } = new List<TblcustomerInvoice>();

    public virtual ICollection<Tblcustomer> Tblcustomers { get; set; } = new List<Tblcustomer>();

    public virtual ICollection<TblorderStock> TblorderStocks { get; set; } = new List<TblorderStock>();

    public virtual ICollection<Tblproduct> Tblproducts { get; set; } = new List<Tblproduct>();

    public virtual ICollection<TblrecivedStockProduct> TblrecivedStockProducts { get; set; } = new List<TblrecivedStockProduct>();

    public virtual ICollection<TblrecivedStock> TblrecivedStocks { get; set; } = new List<TblrecivedStock>();

    public virtual ICollection<Tblsubcategory> Tblsubcategories { get; set; } = new List<Tblsubcategory>();

    public virtual ICollection<Tblvender> Tblvenders { get; set; } = new List<Tblvender>();
}
