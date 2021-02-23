using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        // Customer
        // Add customer order to order table
        public void AddCustomerOrder(Order customerOrder);
        // Look for the order history of a specific customer by providing an id
        public IEnumerable<Order> getOrderByCustomerId(int customerId);
        // Look for the order history of a specific customer by providing its fullname
        public IEnumerable<Order> getOrderByCustomerName(string fullname);

        // Location
        // Add customer order to locationorder table
        public void AddOrderToLocation(Order customerOrder);

    }
}
