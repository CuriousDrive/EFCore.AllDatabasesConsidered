using System;
using System.Collections.Generic;

namespace Northwind.Models
{
    public partial class EmployeeTerritory
    {
        public string Id { get; set; } = null!;
        public string? TerritoryId { get; set; }
        public long? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Territory? Territory { get; set; }
    }
}
