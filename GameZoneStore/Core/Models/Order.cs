using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    internal class Order
    {
        // Order ID
        public int OrderID { get; set; }
        
        // Customer ID
        public int CustomerID { set; get; }
        
        // Customer cart
        private List<Product> _cart = new List<Product>();
        public List<Product> Cart { get { return _cart; } }
        
        // Customer name
        private String CustomerName { get; set; }
        
        // Time Of Order
        private DateTimeOffset _ordertime;
        public DateTimeOffset OrderTime { get { return _ordertime; } }
        
        // Store Location
        public String StoreLocation {get; set; }

        
        // Add product to customer cart
        public void AddToCart(Product item)
        {
            _cart.Add(item);
        }

        // CheckProductQuantity(): Checks quantity of all products is less than 10 and calls method RejectOrder() if
        //                         quantity of product is eqaul or greater than 10. 
        public void CheckProductQuantity()
        {
            foreach (Product item in _cart)
            {
                if (item.Quantity >= 10)
                {
                    RejectOrder(item.Name, item.Type);
                }
            }
        }

        // Currently erases all items of a list
        public void RejectOrder(string itemName, string itemTag)
        {
            Console.WriteLine("Order has exceeded limit for item " + itemName + " from " + itemTag + " section" +
                               "\nOrder has been rejected and deleted. Please check the quanity limits and " +
                               "availability tags to avoid this situation in the future" +
                               "Thank you for visiting GameZone.");
            _cart.Clear();
        }


    }
}
