using System;
using System.Collections.Generic;

#nullable disable

namespace EFDBGameZoneStore.DataAccess.Entities
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
