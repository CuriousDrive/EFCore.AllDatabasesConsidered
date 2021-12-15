using System;
using System.Collections.Generic;

namespace Northwind.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long Id { get; set; }
        public string? ProductName { get; set; }
        public long? SupplierId { get; set; }
        public long? CategoryId { get; set; }
        public string? QuantityPerUnit { get; set; }
        public byte[] UnitPrice { get; set; } = null!;
        public long UnitsInStock { get; set; }
        public long UnitsOnOrder { get; set; }
        public long ReorderLevel { get; set; }
        public long Discontinued { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
