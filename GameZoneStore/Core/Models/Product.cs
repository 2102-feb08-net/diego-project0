using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Product
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product()
        {
        }

        public Product(string type, string name, int id, decimal price, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentNullException("Quantity of product must be greater than 0.", nameof(quantity));
            }
            
            Type = type ?? "None";
            Name = name;
            Id = id;
            Price = price;
            Quantity = quantity;
        }

    }
}
