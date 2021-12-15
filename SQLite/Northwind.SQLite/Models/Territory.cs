using System;
using System.Collections.Generic;

namespace Northwind.Models
{
    public partial class Territory
    {
        public Territory()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
        }

        public string Id { get; set; } = null!;
        public string? TerritoryDescription { get; set; }
        public long RegionId { get; set; }

        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
