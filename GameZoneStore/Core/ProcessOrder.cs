using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class ProcessOrder
    {
        // Customer Record
        Customer localCustomer = new Customer();
        
        // Save Customer information
        public void CheckOut(string firstname, string lastname)
        {
            localCustomer.FirstName = firstname;
            localCustomer.LastName = lastname;

            Random rand = new Random();
            localCustomer.CustomerId = rand.Next(1, 50000);
        }

        // Review Order
        public bool ValidateOrder(Order customerCart, Location localRetail)
        {
            // Check product quantity in order
            // Check inventory product availability for products in the order
            if (customerCart.CheckProductQuantity() && localRetail.UpdateInventory(customerCart.Cart))
            {
                return true;
            }
            
            return false;
            
        }

        // Order Summary
        public void OrderSummary(Order customerCart)
        {
            double orderTotal = 0.0;           
            
            foreach (Product item in customerCart.Cart)
            {
                orderTotal += item.Price; 
                Console.WriteLine("Item: " + item.Name + "\tQuantity: " + item.Quantity + "\tPrice: " + item.Price);
            }

            Console.WriteLine("Total: $" + string.Format("{0:0.00}", orderTotal));

        }

        // Place Order
        public Order PlaceOrder(Order customerCart, Location localStore)
        {
            // Save customer info in the order
            customerCart.CustomerName = localCustomer.FirstName + " " + localCustomer.LastName;
            customerCart.CustomerID = localCustomer.CustomerId;

            // Save Order Details
            Random rand = new Random();
            customerCart.OrderID = rand.Next(1, 500000);
            customerCart.StoreLocation = localStore.Address;
            customerCart.OrderTime = DateTimeOffset.Now;

            Order customerCartCopy = customerCart;

            // Order Placement Confirmation
            Console.WriteLine("Your order has been placed! Your package sould arrive between 3 and 5 days.");

            return customerCartCopy;

        }
        
    }
}
