using System;
using System.Collections.Generic;

namespace Northwind.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Title { get; set; }
        public string? TitleOfCourtesy { get; set; }
        public string? BirthDate { get; set; }
        public string? HireDate { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? HomePhone { get; set; }
        public string? Extension { get; set; }
        public string? Notes { get; set; }
        public long? ReportsTo { get; set; }
        public string? PhotoPath { get; set; }

        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
