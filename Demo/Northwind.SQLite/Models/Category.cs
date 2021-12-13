using System;
using System.Collections.Generic;

namespace Northwind.Models
{
    public partial class Category
    {
        public long Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
