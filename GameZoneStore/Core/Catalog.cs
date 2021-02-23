using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class Catalog
    {
        //Location
        Location localStore = new Location();
        // Customer Order
        private Order _customerOrder = new Order();
        // Catalog
        private List<Product> catalog = new List<Product>();
        
        // Display popular items
        public void DisplayPopularItems()
        {
            foreach(Product item in localStore.Inventory)
            {
                if(item.Quantity > 0 && item.Quantity < 20)
                {
                    Console.WriteLine("Name: " + item.Name + "\t" + item.Id + "\t" + item.Price);
                }
            }
        }
        
        // Display items by category
        public void FilterByCategory(string category)
        {
            foreach (Product item in localStore.Inventory)
            {
                if (item.Quantity > 0 && item.Type.Equals(category) )
                {
                    Console.WriteLine("Name: " + item.Name + "\t" + item.Id + "\t" + item.Price);
                }
            }
        }

        //// Add catalog item to cart
        //public void AddToOrder(int productId)
        //{
        //    Product catalogItem = new Product();
        //    foreach (Product item in localStore.Inventory)
        //    {
        //        if(item.Id == productId)
        //        {
        //            catalogItem = item;
        //            break;
        //        }
        //    }
            
        //    // TODO Allow user to specify amount of selected item

        //    _customerOrder.AddToCart(catalogItem);
        //}

        // Begin order transaction 
        public ProcessOrder GoToOrder()
        {
            ProcessOrder cartTransaction = new ProcessOrder();
            return cartTransaction;

        }

    }
}
