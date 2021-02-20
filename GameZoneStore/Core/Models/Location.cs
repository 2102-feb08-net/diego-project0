using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core
{
    class Location
    {
        private List<Product> _inventory = new List<Product>();
        public List<Product> Inventory { get { return _inventory; } }
        public String Address { get; set; }
        public int Id { get; set; }

        //// Retrieve inventory (from text file)
        //public void RetrieveInventory()
        //{
 
        //    // Read File
        //    foreach (string line in File.ReadLines("C:/revature/revproject0/GameZoneStore/Core/Inventory/TextFile1.txt"))
        //    {
        //        if (line.Contains("Type:") && line.Contains("."))
        //        {
        //            string[] inventoryProduct = line.Split(',','.');
        //            SaveInventory(inventoryProduct);
        //        }
        //    }
            
        //}

        //public void SaveInventory(string[] inventoryProduct)
        //{
        //    Product productDetails = new Product();
        //    productDetails.Type = inventoryProduct[0];
        //    productDetails.Name = inventoryProduct[1];
        //    productDetails.Id = int.Parse(inventoryProduct[2]);
        //    productDetails.Price = double.Parse(inventoryProduct[3]);
        //    productDetails.Quantity = int.Parse(inventoryProduct[(inventoryProduct.Length - 1)]);

        //    _inventory.Add(productDetails);

        //}

        // Retrieve inventory (from list)
        public void RetrieveInventory(List<Product> supplier)
        {
            foreach(Product supplierItem in supplier)
            {
                _inventory.Add(supplierItem);
            }
        }

        // Update inventory. 
        // Remove items in inventory as orders are processed and approved
        public bool UpdateInventory(List<Product> order)
        {
            
            // Remove quantity of a specific product in inventory based on order
            foreach (Product item in _inventory)
            {
                foreach(Product customerItem in order)
                {
                    if(item.Id == customerItem.Id && ((item.Quantity - customerItem.Quantity) > 0))
                    {
                        item.Quantity -= customerItem.Quantity;
                    }
                    else
                    {
                        RejectOrder(customerItem.Name, order);
                        return false;
                    }
                }
            }
            
            return true;
            
        }

        // Reject Order
        // Cancel an order due to shortage of specific item in inventory
        public void RejectOrder(String item, List<Product> order)
        {
            Console.WriteLine("Order has been rejected due to the following out of stock item: " + item);
            order.Clear();
        }
    }
}
