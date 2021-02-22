using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using EFDBGameZoneStore.DataAccess.Entities;

namespace EFDBGameZoneStore.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        // Repository
        private readonly project0rincongamezonestoreContext _dbContext;

        // Initialize Repository
        // Uses null coalescing operator to throw an error in case the dbcontext is null
        public CustomerRepository(project0rincongamezonestoreContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        // Get all products from GameZone Database
        public void AddCustomer(Core.Customer cust)
        {
            var entity = new Customer
            {
                FistName = cust.FirstName,
                LastName = cust.LastName,
                CustomerId = cust.CustomerId
            };

            _dbContext.Add(entity);
        }

        // Save changes to database
        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }
}
