using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class Catalog
    {
        // Order
        private Order cart = new Order();
        // Location
        private Location defaultLocation = new Location();
        // Catalog
        private List<Product> catalog = new List<Product>();
        // Data Access Catalog Repo

        // Change Location
        
        // Display Catalog

        // Browse by category
        
        // Add to cart
        public void AddToCart(Product item)
        {
            cart.AddProduct(item.Type, item.Name, item.Id, item.Price, item.Quantity);
        }

        // Check out
        public void CheckOut(ProcessOrder cashier, String customerName)
        {
            if(cashier.IsOrderValid(cart, defaultLocation))
            {
                cashier.OrderSummary(cart);
                cart.SetCustomerName(customerName);
                cashier.PlaceOrder(cart); 
            }
        }

    }
}
