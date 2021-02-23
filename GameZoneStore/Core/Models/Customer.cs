using System;

namespace Core
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }

        public Customer()
        {
        }
        
        public Customer(string firstName, string lastName)
        {
            if (ValidateName(firstName, lastName))
            {
                FirstName = firstName;
                LastName = lastName;
            }

        }

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
