using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class ProcessOrder
    {
        // Review Order
        public bool IsOrderValid(Order cart, Location localRetail)
        {
            // Check product quantity in order
            cart.CheckProductQuantity();

            // Check inventory product availability for products in the order
            if (localRetail.IsInventoryUpdated(cart.Products))
            {
                return true;
            }
            
            return false;
            
        }

        // Order Summary
        public void OrderSummary(Order cart)
        {
            double orderTotal = 0.0;           
            
            foreach (Product item in cart.Products)
            {
                orderTotal += item.Price; 
                Console.WriteLine("Item: " + item.Name + "\tQuantity: " + item.Quantity + "\tPrice: " + item.Price);
            }

            Console.WriteLine("Total: $" + String.Format("{0:0.00}", orderTotal));

        }

        // Place Order
        public void PlaceOrder(Order cart)
        {
            // Save customer information

            // Save/update retail store information

            // Order Placement Confirmation
            Console.WriteLine("Your order has been placed! Your package sould arrive between 3 and 5 days.");
        }
        
    }
}
