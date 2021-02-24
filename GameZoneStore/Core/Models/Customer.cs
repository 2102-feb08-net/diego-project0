using System;

namespace Core
{
    public class Customer
    {
        /// <summary>
        /// Customer First Name.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Customer Last Name.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Customer Id.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Empty Constructor for queries. 
        /// </summary>
        public Customer()
        {
        }
        
        /// <summary>
        /// Constructor for use of UI.
        /// </summary>
        public Customer(string firstName, string lastName)
        {
            if (ValidateName(firstName, lastName))
            {
                FirstName = firstName;
                LastName = lastName;
            }

        }

        /// <summary>
        /// Validate first name and last name provided by user input.
        /// </summary>
        public bool ValidateName(string fname, string lname)
        {
            // Validate customer name
            if (fname is null || lname is null)
            {
                throw new ArgumentNullException("First and last name must not be empty.", nameof(fname));
            }
            
            foreach(char letter in fname)
            {
                if (!(Char.IsLetter(letter)))
                {
                    throw new ArgumentException("Use letters only.", nameof(fname));
                }
            }

            foreach(char letter in lname)
            {
                if (!(Char.IsLetter(letter)))
                {
                    throw new ArgumentException("Use letters only.", nameof(lname));
                }
            }
            
            return true;
        }
    }
}
