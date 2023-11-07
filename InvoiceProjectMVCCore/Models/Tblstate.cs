using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class Tblstate
{
    public int StateId { get; set; }

    public string? StateName { get; set; }

    public virtual ICollection<Tblcity> Tblcities { get; set; } = new List<Tblcity>();
}
