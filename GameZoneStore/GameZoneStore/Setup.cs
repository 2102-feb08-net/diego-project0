using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDBGameZoneStore.DataAccess.Entities;
using EFDBGameZoneStore.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace GameZoneStore
{
    class Setup
    {
        // Create DBContextOptions
        public project0rincongamezonestoreContext CreateContext()
        {
            string connectionString = File.ReadAllText("C:/revature/Connection/connection.txt");
            DbContextOptionsBuilder<project0rincongamezonestoreContext> contextOptionsBuilder = new DbContextOptionsBuilder<project0rincongamezonestoreContext>().UseSqlServer(connectionString);

            return new project0rincongamezonestoreContext(contextOptionsBuilder.Options);
        }

        public ICustomerRepository CreateCustomerRepository()
        {
            var dbContext = CreateContext();
            return new CustomerRepository(dbContext);
        }

    }
}
