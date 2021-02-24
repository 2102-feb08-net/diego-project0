using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICustomerRepository
    {
        // Add Customer to Database
        public void AddCustomer(Customer cust);

        // Get customer given the first name and id
        public Customer GetCustomer(string fname, int id);

        // Save changes to Database
        public IEnumerable<Customer> GetCustomers();

        public void Save();
    }
}
