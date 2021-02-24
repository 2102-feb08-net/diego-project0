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
        public void AddOrder(Order customerOrder);
        // Get Order id based on a specific customer id
        public int GetOrderIdByCustomerId(int customerId);
        // Add customer order details to order table 
        public void AddOrderDetails(Order customerOrder, int orderId);
        // Display orders of a specific customer
        public IEnumerable<Order> GetCustomerOrderDetails();

        public void Save();
    }
}
