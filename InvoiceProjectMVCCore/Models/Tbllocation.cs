using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class Tbllocation
{
    public int LocationId { get; set; }

    public string? Location { get; set; }

    public int? CityId { get; set; }

    public virtual Tblcity? City { get; set; }

    public virtual ICollection<Tblcustomer> Tblcustomers { get; set; } = new List<Tblcustomer>();

    public virtual ICollection<Tbluser> Tblusers { get; set; } = new List<Tbluser>();
}
