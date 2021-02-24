using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Product
    {
        /// <summary>
        /// Type of product.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Name of product.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Product Id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Price of product. In the inidvidual context it represents the unit price. In the context
        /// of the customer it represents the total price given a specific quantity.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity of product. Used by the customer.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Empty constructor for queries.
        /// </summary>
        public Product()
        {
        }

        /// <summary>
        /// Constructor for use of order class.
        /// </summary>
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
