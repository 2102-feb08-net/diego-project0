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

        // Add customer to GameZone Database
        public void AddCustomer(Core.Customer cust)
        {
            var entity = new Customer
            {
                FistName = cust.FirstName,
                LastName = cust.LastName
            };

            _dbContext.Add(entity);
        }

        // Show list of customers
        public IEnumerable<Core.Customer> GetCustomers()
        {
            IQueryable<Customer> customers = _dbContext.Customers;

            return customers.Select(c => new Core.Customer
            {
                Id = c.CustomerId, 
                FirstName = c.FistName, 
                LastName = c.LastName
            }).ToList();

        } 

        // Save changes to database
        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }
}
