using System;
using System.Collections.Generic;

namespace Northwind.Models
{
    public partial class OrderDetail
    {
        public string Id { get; set; } = null!;
        public byte[] UnitPrice { get; set; } = null!;
        public long Quantity { get; set; }
        public double Discount { get; set; }
        public long? ProductId { get; set; }
        public long? OrderId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
