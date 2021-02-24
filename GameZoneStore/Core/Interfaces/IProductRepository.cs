using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Get all Products from Database.
        /// </summary> 
        public IEnumerable<Product> GetProducts();

        /// <summary>
        /// Save changes to database.
        /// </summary>
        public void Save();
    }
}
