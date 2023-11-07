using System;
using System.Collections.Generic;

namespace InvoiceProjectMVCCore.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public double? EmployeeSalary { get; set; }

    public string? EmployeeJoiningDate { get; set; }
}
