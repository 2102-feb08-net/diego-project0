using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Order
    {
        /// <summary>
        /// Order ID.
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// Customer ID.
        /// </summary>
        public int CustomerID { set; get; }
        
        /// <summary>
        /// Dictionary containing customer order products.
        /// </summary>
        private Dictionary<Product, int> _cart = new Dictionary<Product, int>();
        public Dictionary<Product, int> Cart { get { return _cart; } }
        
        /// <summary>
        /// Time the order was placed.
        /// </summary>
        private DateTimeOffset _ordertime;
        public DateTimeOffset OrderTime { set { _ordertime = value; } get { return _ordertime; } }
        
        /// <summary>
        /// Order total.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Constructor for the use of queries.
        /// </summary>
        public Order()
        {
        }

        /// <summary>
        /// Add product to customer order.
        /// </summary>
        public void AddToCart(Product item, int productQuantity)
        {
            if (productQuantity >= 1)
            {
                Product itemCopy = item;
                itemCopy.Quantity = productQuantity;
                itemCopy.Price *= productQuantity;
                _cart.Add(itemCopy, productQuantity);
            }
            else
            {
                throw new ArgumentException("Product quantity must be at least 1.", nameof(productQuantity));
            }
            

        }

        /// <summary>
        /// Checks quantity of all products in customer order is less than 10 and calls method RejectOrder() if
        /// quantity of product is equal or greater than 10.
        /// </summary>
        public bool CheckProductQuantity()
        {
            foreach (var item in _cart)
            {
                if (item.Key.Quantity >= 10)
                {
                    RejectOrder(item.Key.Name, item.Key.Type);
                    return false;
                }

            }

            return true;

        }

        // Currently erases all items of a list
        /// <summary>
        /// Removes all products from the customer order.
        /// </summary>
        public void RejectOrder(string itemName, string itemTag)
        {
            Console.WriteLine("Order has exceeded limit for item " + itemName + " from " + itemTag + " section" +
                               "\nOrder has been rejected and deleted. Please check the quanity limits and " +
                               "availability tags to avoid this situation in the future" +
                               "Thank you for visiting GameZone.");
            _cart.Clear();
        }

        // Order Summary
        /// <summary>
        /// Displays a summary of all the products in the customer order.
        /// </summary>
        public void OrderSummary()
        {
            decimal total = 0;
            int productCount = 0;
            
            foreach (var p in _cart)
            {
                Console.WriteLine("Product Id: " + p.Key.Id + "\tType: " + p.Key.Type + "\tName: " + p.Key.Name + "\tQuantity: " + p.Key.Quantity + "\tTotal Price: " + (p.Key.Price));
                total += p.Key.Price;
                
                productCount += p.Key.Quantity;
            }

            Console.WriteLine($"{productCount} Item(s): {total}");
            Total = total;
        }



    }
}
