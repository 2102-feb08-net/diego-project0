using Core.Interfaces;
using EFDBGameZoneStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDBGameZoneStore.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // Repository
        private readonly project0rincongamezonestoreContext _dbContext;

        // Initialize Repository
        // Uses null coalescing operator to throw an error in case the dbcontext is null
        public ProductRepository(project0rincongamezonestoreContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        // Get all Products from Database
        public IEnumerable<Core.Product> GetProducts()
        {
            IQueryable<Product> items = _dbContext.Products;

            return items.Select(p => new Core.Product
            {
                Type = p.Type, 
                Name = p.Name, 
                Id = p.ProductId, 
                Price = p.Price
            }).ToList();
        }

        // Save changes to database
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
