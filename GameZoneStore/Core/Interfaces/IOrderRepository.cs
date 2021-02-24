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
        /// <summary>
        /// Add customer order to database order table.
        /// </summary>
        /// <param name="customerOrder"></param>
        public void AddOrder(Order customerOrder);

        /// <summary>
        /// Get Order id from database based on a specific customer id.
        /// </summary>
        public int GetOrderIdByCustomerId(int customerId);

        ///<summary>
        /// Add customer order details to database orderdetails table.
        ///</summary>
        public void AddOrderDetails(Order customerOrder, int orderId);

        /// <summary>
        /// Display all orders from database.
        /// </summary>
        public IEnumerable<Order> GetCustomerOrderDetails();

        /// <summary>
        /// Save changes to Database.
        /// </summary>
        public void Save();
    }
}
