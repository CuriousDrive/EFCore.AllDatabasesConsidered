using System;
using System.Collections.Generic;

namespace Northwind.Models
{
    public partial class OrderDetail
    {
        public string Id { get; set; } = null!;
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public byte[] UnitPrice { get; set; } = null!;
        public long Quantity { get; set; }
        public double Discount { get; set; }
    }
}
