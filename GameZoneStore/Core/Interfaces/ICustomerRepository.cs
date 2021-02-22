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

        // Save changes to Database
        public void Save();
    }
}
