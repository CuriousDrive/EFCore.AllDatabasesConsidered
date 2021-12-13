using System;
using System.Collections.Generic;

namespace Northwind.Models
{
    public partial class ProductDetail
    {
        public long? Id { get; set; }
        public string? ProductName { get; set; }
        public long? SupplierId { get; set; }
        public long? CategoryId { get; set; }
        public string? QuantityPerUnit { get; set; }
        public byte[]? UnitPrice { get; set; }
        public long? UnitsInStock { get; set; }
        public long? UnitsOnOrder { get; set; }
        public long? ReorderLevel { get; set; }
        public long? Discontinued { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierRegion { get; set; }
    }
}
