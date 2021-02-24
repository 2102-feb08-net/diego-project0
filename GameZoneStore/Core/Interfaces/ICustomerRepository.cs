using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Add Customer to Database.
        /// </summary>
        public void AddCustomer(Customer cust);

        /// <summary>
        /// Get customer from database given the first name and id.
        /// </summary>
        public Customer GetCustomer(string fname, int id);

        /// <summary>
        /// Save changes to Database.
        /// </summary>
        public IEnumerable<Customer> GetCustomers();

        public void Save();
    }
}
