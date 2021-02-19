using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    internal class Order
    {
        private List<Product> _products = new List<Product>();
        private Customer _customerName = new Customer();
        private DateTime _ordertime;
        public String StoreLocation {get; set; }

        // Retrieve List of products in order
        public List<Product> Products { get; }

        // Retrieve and set the time of order placement
        public DateTime OrderTime
        {
            get { return _ordertime; }

            set { _ordertime = value; }
        }

        // Save Customer Information
        public Customer CustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                string fullname = value.ToString();
                string[] separateName = fullname.Split(' ');
                _customerName.FirstName = separateName[0];
                _customerName.LastName = separateName[1];
            }
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

            _products.Add(item);

        }

        // CheckProductQuantity(): Checks quantity of all products is less than 10 and calls method RejectOrder() if
        //                         quantity of product is eqaul or greater than 10. 
        public void CheckProductQuantity()
        {
            foreach (Product item in _products)
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
            _products.Clear();
        }


    }
}
