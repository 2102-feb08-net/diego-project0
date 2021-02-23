using Core;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneStore
{
    class StoreMainMenu
    {
        // Keep customer in main menu
        public void RunMainMenu()
        {
            // Set up connection to data access layer
            using var setup = new Setup();
            // Get repositories
            ICustomerRepository customerRepository = setup.CreateCustomerRepository();
            IProductRepository productRepository = setup.CreateProductRepository();

            WelcomeMenu();

            string userInput = "";
            while (!userInput.Equals("GQuit"))
            {
                // Prompt
                Console.Write("*");
                userInput = Console.ReadLine();
                
                // Handle commands
                if (userInput.Equals("GHelp"))
                {
                    ShowMenuCommands();
                }

                else if (userInput.Contains("GAdd Customer"))
                {
                    RegisterCustomer(customerRepository);
                }

                else if (userInput.Equals("GList Customers"))
                {
                    ShowCustomers(customerRepository);
                }

                else if(userInput.Equals("GShow Products"))
                {
                    ShowProducts(productRepository);
                }

                else
                {
                    if (!userInput.Equals("GQuit"))
                    {
                        Console.WriteLine("Invalid command. Type GHelp to list menu commands.\n");
                    }
                }
            }
        }
        

        // Welcome message
        public void WelcomeMenu()
        {
            Console.WriteLine("Welcome to GameZone Store.");
            Console.WriteLine("List of commands");
            Console.WriteLine("GHelp - Shows menu commands.");
            Console.WriteLine("GAdd Customer <first name> <lastname> - adds a customer to our records.");
            Console.WriteLine("GList Customers - Shows a list of all customers in our records.");
            Console.WriteLine("GShow Products - shows the products in our store.");
            Console.WriteLine("GAdd To Cart <item name> <quantity> - adds a product to the order with specified quantity");
            Console.WriteLine("GReview Order - shows a summary of the items in the order.");
            Console.WriteLine("GPlace Order - place order to our store.");
            Console.WriteLine("GQuit - exit store.");
            Console.WriteLine();
        }

        
        // Show menu options
        public void ShowMenuCommands()
        {
            Console.WriteLine("GHelp - Shows menu commands.");
            Console.WriteLine("GAdd Customer <first name> <lastname> - adds a customer to our records.");
            Console.WriteLine("GShow Products - shows the products in our store.");
            Console.WriteLine("GAdd To Cart <item name> <quantity> - adds a product to the order with specified quantity");
            Console.WriteLine("GReview Order - shows a summary of the items in the order.");
            Console.WriteLine("GPlace Order - place order to our store.");
            Console.WriteLine("GQuit - exit store.");
            Console.WriteLine();
        }

        // Add customer
        public void RegisterCustomer(ICustomerRepository customer)
        {
            Console.WriteLine("Please provide a first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please provide a last name: ");
            string lastName = Console.ReadLine();

            Customer newCustomer = new Customer(firstName, lastName);

            customer.AddCustomer(newCustomer);
            customer.Save();
            Console.WriteLine("Customer added successfully.");
        }

        // Show customers
        public void ShowCustomers(ICustomerRepository customer)
        {
            foreach(Customer c in customer.GetCustomers().ToList())
            {
                Console.WriteLine("Id: " + c.Id + "\tFirst Name: " + c.FirstName + "\tLast Name: " + c.LastName);
            }
            Console.WriteLine();
        }

        // Show products
        public void ShowProducts(IProductRepository products)
        {
            foreach(Product p in products.GetProducts().ToList())
            {
                Console.WriteLine("Id: " + p.Id + "\tType: " + p.Type + "\tName: " + p.Name + "\tPrice: " + p.Price);
            }
            Console.WriteLine();
        }
        // Add To Order

        // Review Order
        
        // Place Order

        // Show orders
    }
}
