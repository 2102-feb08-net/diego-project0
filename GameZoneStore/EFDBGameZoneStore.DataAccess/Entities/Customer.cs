using System;
using System.Collections.Generic;

#nullable disable

namespace EFDBGameZoneStore.DataAccess.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
