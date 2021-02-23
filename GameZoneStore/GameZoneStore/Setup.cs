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
using Microsoft.EntityFrameworkCore.Design;

namespace GameZoneStore
{
    public class Setup : IDesignTimeDbContextFactory<project0rincongamezonestoreContext>, IDisposable
    {
        private bool _disposed = false;
        private readonly List<IDisposable> _disposableInterfaces = new List<IDisposable>();

        // Create DBContextOptionsBuilder
        public project0rincongamezonestoreContext CreateDbContext(string[] args = null)
        {
            var builder = new DbContextOptionsBuilder<project0rincongamezonestoreContext>();
            string connectionString = File.ReadAllText("C:/revature/Connection/connection.txt");

            builder.UseSqlServer(connectionString);
            
            return new project0rincongamezonestoreContext(builder.Options);
        }

        // Customer Repository
        public ICustomerRepository CreateCustomerRepository()
        {
            var dbContext = CreateDbContext();
            _disposableInterfaces.Add(dbContext);
            return new CustomerRepository(dbContext);
        }

        // Product Repository
        public IProductRepository CreateProductRepository()
        {
            var dbContext = CreateDbContext();
            _disposableInterfaces.Add(dbContext);
            return new ProductRepository(dbContext); 
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Release of managed resources
                    foreach (IDisposable disposable in _disposableInterfaces)
                    {
                        disposable.Dispose();
                    }
                }
                // Release of unmanaged resources
                _disposed = true;
            }
        }

    }
}
