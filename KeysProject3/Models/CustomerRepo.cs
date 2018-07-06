using KeysProject3.Models;
using System.Collections.Generic;
using System.Linq;

namespace KeysProject3.Models
{
    /// <summary>
    /// Customer data repository
    /// </summary>
    public class CustomerRepo
    {
        private static MVC3Entities _customerDb;
        private static MVC3Entities CustomerDb
        {
            get { return _customerDb ?? (_customerDb = new MVC3Entities()); }
        }

        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <returns>IEnumerable Customer List</returns>
        public static IEnumerable<Customer> GetCustomers()
        {
            var query = from customers in CustomerDb.Customers select customers;
            return query.ToList();
        }

        /// <summary>
        /// Inserts the customer to database.
        /// </summary>
        /// <param name="customer">The customer object to insert.</param>
        public static void InsertCustomer(Customer customer)
        {
            CustomerDb.Customers.Add(customer);
            CustomerDb.SaveChanges();
        }

        /// <summary>
        /// Deletes Customer from database.
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        public static void DeleteCustomer(int customerId)
        {
            var deleteItem = CustomerDb.Customers.FirstOrDefault(c => c.Id == customerId);

            if (deleteItem != null)
            {
                CustomerDb.Customers.Remove(deleteItem);
                CustomerDb.SaveChanges();
            }
        }
    }
}