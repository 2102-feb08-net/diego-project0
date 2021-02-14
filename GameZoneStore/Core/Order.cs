using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    internal class Order
    {
        private DateTime _ordertime;
        private List<Product> products = new List<Product>();

        // Retrieve and set the time of order placement
        public DateTime OrderTime
        {
            get { return _ordertime;}

            set { _ordertime = value;}
        }

        // AddProduct(): Add different types of products to the order
        // CheckProductQuantity(): Helper method of AddProduct(). Currently checks product of same type and name does not have more than 10 occurences. 
        //                         Otherwise, it rejects the order. Will later use inventory of Location as a constraint rather than the 10 occurences in list.
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
                int duplicateCount = 0;

                foreach (Product p1 in products)
                {
                    foreach (Product p2 in products)
                    {
                        if (p2.Name.Equals(p1.Name) && p2.Type.Equals(p1.Type))
                        {
                            duplicateCount++;

                            if (duplicateCount == 10)
                            {
                                RejectOrder(p1.Name, p1.Type);
                            }

                        }
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
