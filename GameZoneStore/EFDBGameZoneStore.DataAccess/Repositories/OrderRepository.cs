using Core.Interfaces;
using EFDBGameZoneStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDBGameZoneStore.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        // Repository
        private readonly project0rincongamezonestoreContext _dbContext;

        // Initialize Repository
        // Uses null coalescing operator to throw an error in case the dbcontext is null
        public OrderRepository(project0rincongamezonestoreContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        // Add Customer Order to Database
        public void AddOrder(Core.Order order)
        {
            var customerOrder = new Order
            {
                CustomerId = order.CustomerID, 
                OrderDate = order.OrderTime, 
                OrderTotal = order.Total
            };

            _dbContext.Add(customerOrder);
        }

        // Get customer order by id
        public int GetOrderIdByCustomerId(int customerId)
        {
            Order order = _dbContext.Orders.Find(customerId);
            int orderId = order.OrderId;

            return orderId;

        }

        // Add Csutomer Order Details to Database
        public void AddOrderDetails(Core.Order order, int orderId)
        {
            List<Core.Product> items = new List<Core.Product>(order.Cart.Keys);
            
            foreach(Core.Product p in items)
            {
                var orderDetails = new OrderDetail
                {
                    OrderId = orderId, 
                    ProductId = p.Id, 
                    Quantity = p.Quantity, 
                    TotalPrice = p.Price
                };

                _dbContext.Add(orderDetails);
            }
        }

        // Display orders of a specific customer
        public IEnumerable<Core.Order> GetCustomerOrderDetails()
        {
            var orderdetails = _dbContext.Orders.Include(o => o.OrderDetails);

            return orderdetails.Select(od => new Core.Order
            {
                OrderID = od.OrderId,
                CustomerID = od.CustomerId,
                OrderTime = od.OrderDate,
                Total = od.OrderTotal


            }).ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
