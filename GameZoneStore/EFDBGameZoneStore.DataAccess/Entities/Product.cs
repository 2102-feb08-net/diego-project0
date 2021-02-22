using System;
using System.Collections.Generic;

#nullable disable

namespace EFDBGameZoneStore.DataAccess.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
