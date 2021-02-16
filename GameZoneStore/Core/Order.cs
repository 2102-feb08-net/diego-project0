using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    internal class Order
    {
        private DateTime _ordertime;
        private List<Product> products = new List<Product>();


        // Retrieve List of products in order
        public List<Product> Products { get; }

        // Retrieve and set the time of order placement
        public DateTime OrderTime
        {
            get { return _ordertime; }

            set { _ordertime = value; }
        }

        // AddProduct(): Add different types of products to the order
        public void AddProduct(string kind, string name, int id, double cost, int quantity)
        {
            Product item = new Product();
            item.Type = kind;
            item.Name = name;
            item.Id = id;
            item.Price = cost;
            item.Quantity = quantity;

            products.Add(item);

        }

        // CheckProductQuantity(): Checks quantity of all products is less than 10 and calls method RejectOrder() if
        //                         quantity of product is eqaul or greater than 10. 
        public void CheckProductQuantity()
        {
            foreach (Product item in products)
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
            products.Clear();
        }


    }
}
