using System;
using System.Collections.Generic;
using System.Text;

namespace _5212AssignmentB
{
    class Customer
    {
        // Properties
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }

        // Constructors
        // Initializes the properties in the Customer class for use in the Form1
        public Customer(string fn, string ln, string ph)
        {
            FName = fn;
            LName = ln;
            Phone = ph;
        }

        // Methods
        // Gets the information for the customer and outputs it into a string form using tabs
        public string GetCustomer()
        {
            string customerDetails = $"{FName}\t{LName}\t{Phone}";
            return customerDetails;
        }
    }
}
