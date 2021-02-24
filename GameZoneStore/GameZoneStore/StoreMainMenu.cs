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
        // Order
        Core.Order customerOrder = new Core.Order();

        // Inventory
        List<Core.Product> inventory = new List<Core.Product>();

        // Customer
        Core.Customer customerAccount = new Core.Customer();

        // Check customer is logged in
        private bool _loggedIn = false;

        // Keep customer in main menu
        public void RunMainMenu()
        {
            // Set up connection to data access layer
            using var setup = new Setup();
            // Get repositories
            ICustomerRepository customerRepository = setup.CreateCustomerRepository();
            IProductRepository productRepository = setup.CreateProductRepository();
            IOrderRepository orderRepository = setup.CreateOrderRepository();
            // Load Inventory
            LoadInventory(productRepository);

            WelcomeMenu();

            string userInput = "";
            while (!userInput.Equals("GQuit"))
            {
                // Prompt
                Console.Write("*");
                userInput = Console.ReadLine();
                
                // Handle commands
                // Customer
                if (userInput.Equals("GHelp"))
                {
                    ShowMenuCommands();
                }

                else if (userInput.Contains("GAdd Customer") && !_loggedIn)
                {
                    RegisterCustomer(customerRepository);
                }

                else if (userInput.Equals("GList Customers") && !_loggedIn)
                {
                    ShowCustomers(customerRepository);
                }

                else if (userInput.Equals("GLog In") && !_loggedIn)
                {
                    LogInCustomer(customerRepository);
                }

                else if (userInput.Equals("GLog Out"))
                {
                    LogOutCustomer(customerRepository);
                }

                // Products
                else if(userInput.Equals("GList Products"))
                {
                    ShowProducts();
                }

                // Order
                else if (userInput.Equals("GAdd To Cart"))
                {
                    AddToOrder();
                }

                else if (userInput.Equals("GReview Order"))
                {
                    ReviewOrder();
                }

                else if(userInput.Equals("GPlace Order"))
                {
                    PlaceOrder(orderRepository);
                }

                else if (userInput.Equals("GList Orders"))
                {
                    ListOrders(orderRepository);
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
        

        // MENU
        // Welcome message
        public void WelcomeMenu()
        {
            Console.WriteLine("Welcome to GameZone Store.");
            Console.WriteLine("Type GHelp to list menu commands");
            Console.WriteLine();
        }
        // Show menu options
        public void ShowMenuCommands()
        {
            Console.WriteLine("GHelp - Shows menu commands.");
            Console.WriteLine("GAdd Customer - Adds a customer to our records.");
            Console.WriteLine("GList Customers - Shows the list of customers in our records.");
            Console.WriteLine("GLog In - Log in to customer account.");
            Console.WriteLine("GLog Out - Log out of customer ");
            Console.WriteLine("GList Products - Shows the list of products in our store.");
            Console.WriteLine("GAdd To Cart - Adds a product to the order with specified quantity");
            Console.WriteLine("GReview Order - Shows a summary of the items in the order.");
            Console.WriteLine("GPlace Order - Place order to our store.");
            Console.WriteLine("GList Orders - Place order to our store.");
            Console.WriteLine("GQuit - Exit store.");
            Console.WriteLine();
        }

        // CUSTOMER
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
            Console.WriteLine("Customer added successfully.\n");
        }
        // Log in to customer account
        public void LogInCustomer (ICustomerRepository customer)
        {
            string username = "";
            string password = "";

            Console.WriteLine("Please provide first name: ");
            username = Console.ReadLine();

            Console.WriteLine("Please provide id: ");
            password = Console.ReadLine();

            customerAccount = customer.GetCustomer(username, int.Parse(password));
            Console.WriteLine($"Welcome {customerAccount.FirstName}");
            _loggedIn = true;
        }
        // Log out from customer account
        public void LogOutCustomer(ICustomerRepository customer)
        {
            customerAccount = null;
            _loggedIn = false;
            Console.WriteLine("You have logged out of your account.\n");
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

        // PRODUCTS
        // Show products
        public void ShowProducts()
        {
            foreach(Product p in inventory)
            {
                Console.WriteLine("Id: " + p.Id + "\tType: " + p.Type + "\tName: " + p.Name + "\tPrice: " + p.Price);
            }
            Console.WriteLine();
        }
        // Fetch Products
        public void LoadInventory(IProductRepository products)
        {
            foreach (Product p in products.GetProducts().ToList())
            {
                inventory.Add(p);
            }
            Console.WriteLine();
        }

        // ORDER
        // Add To Order
        public void AddToOrder()
        {
            string userProduct = "";
            int productId = 0;
            string userQuantity = "";
            int productQuantity = 0;
            
            Console.WriteLine("Please provide id of product: ");
            userProduct = Console.ReadLine();
            productId = int.Parse(userProduct);

            Console.WriteLine("Please provide a quantity for the product: ");
            userQuantity = Console.ReadLine();
            productQuantity = int.Parse(userQuantity);

            foreach (Product p in inventory)
            {
                if(p.Id == productId)
                {
                    customerOrder.AddToCart(p, productQuantity);
                }
            }

            if (customerOrder.CheckProductQuantity())
            {
                Console.WriteLine("Cart has been updated.");
            }
            
        } 
        // Review Order
        public void ReviewOrder()
        {
            customerOrder.OrderSummary();
        }
        // Place Order
        public void PlaceOrder(IOrderRepository order)
        {
            if (_loggedIn)
            {
                int orderId = 0;
                
                // Order Set up
                customerOrder.CustomerID = customerAccount.Id;
                customerOrder.OrderTime = DateTimeOffset.Now;

                //Order Placement
                order.AddOrder(customerOrder);
                order.Save();

                orderId = order.GetOrderIdByCustomerId(customerOrder.CustomerID);
                order.AddOrderDetails(customerOrder, orderId);
                order.Save();
            }
            else
            {
                Console.WriteLine("Please use the command GLogIn and enter credentials to proceed to order placement.");
            }
        }

        // Show orders
        public void ListOrders(IOrderRepository order)
        {
            if (_loggedIn)
            {
                foreach (Order co in order.GetCustomerOrderDetails())
                {
                    Console.WriteLine("Order Id: " + co.OrderID + "\tCustomerId: " + co.CustomerID + "\tDate: " + co.OrderTime + "\tTotal" + co.Total);
                }
            }
            else
            {
                Console.WriteLine("Please log in to see order details");
            }
            
        }
    }
}
