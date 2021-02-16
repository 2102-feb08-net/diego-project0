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
        // CheckProductQuantity(): Helper method of AddProduct(). Currently checks product of same type and name does not have more than 10 occurences. 
        //                         Otherwise, it rejects the order. 
        public void AddProduct(string kind, string name, int id, double cost)
        {
            CheckProductQuantity();

            Product item = new Product();
            item.Type = kind;
            item.Name = name;
            item.Id = id;
            item.Price = cost;
            products.Add(item);

        }

        public void CheckProductQuantity()
        {
            if (products.Count != 0)
            {
               foreach(Product p in products)
                {
                    if (p.Quantity >= 10)
                    {
                        RejectOrder(p.Name, p.Type);
                    }
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
