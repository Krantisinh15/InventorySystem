using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class Tblcity
{
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public int? StateId { get; set; }

    public virtual Tblstate? State { get; set; }

    public virtual ICollection<Tbllocation> Tbllocations { get; set; } = new List<Tbllocation>();
}
