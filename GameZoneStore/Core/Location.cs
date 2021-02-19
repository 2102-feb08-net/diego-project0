using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core
{
    class Location
    {
        private List<Product> _inventory = new List<Product>();
        public String Address { get; set; }
        public List<Product> Inventory { get { return _inventory; } }


        // Retrieve inventory
        public void RetrieveInventory()
        {
 
            // Read File
            foreach (string line in File.ReadLines("C:/revature/revproject0/GameZoneStore/Core/Inventory/TextFile1.txt"))
            {
                if (line.Contains("Type:") && line.Contains("."))
                {
                    string[] inventoryProduct = line.Split(',','.');
                    SaveInventory(inventoryProduct);
                }
            }
            
        }

        public void SaveInventory(string[] inventoryProduct)
        {
            Product productDetails = new Product();
            productDetails.Type = inventoryProduct[0];
            productDetails.Name = inventoryProduct[1];
            productDetails.Id = int.Parse(inventoryProduct[2]);
            productDetails.Price = double.Parse(inventoryProduct[3]);
            productDetails.Quantity = int.Parse(inventoryProduct[(inventoryProduct.Length - 1)]);

            _inventory.Add(productDetails);

        }

        // Check remaining inventory
        public void InventorySummary()
        {
            foreach (Product p in _inventory)
            {
                Console.WriteLine(p.Id + "\t" + p.Type + "\t" + p.Name + "\t" + p.Quantity);
            }
        }

        // Update inventory. 
        // Remove items in inventory as orders are processed and approved
        public void UpdateInventory(List<Product> order)
        {
            
            // Remove quantity of a specific product in inventory based on order
            foreach (Product item in _inventory)
            {
                foreach(Product customerItem in order)
                {
                    if(item.Id == customerItem.Id && item.Quantity > 0)
                    {
                        item.Quantity -= 1 ; 
                    }
                    else
                    {
                        RejectOrder(customerItem.Name, order);
                    }
                }
            }
            
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
