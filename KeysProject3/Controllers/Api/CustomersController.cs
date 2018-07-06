using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KeysProject3.Models;
using KeysProject3.Controllers;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Threading.Tasks;

namespace KeysProject3.Controllers.Api
{

    public class CustomersController : ApiController
    {
        //DbContext
        private readonly MVC3Entities db;

        public CustomersController()
        {
            db = new MVC3Entities();
        }


        //GET api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return db.Customers.ToList();
        }

        //GET api/customers/id
        public Customer GetCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        //POST api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            db.Customers.Add(customer);
            db.SaveChanges();

            return customer;
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDb.Id = customer.Id;
            customerInDb.Name = customer.Name;
            customerInDb.Address = customer.Address;

            db.SaveChanges();
        }

        //DELETE /api/customer/id
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Customers.Remove(customerInDb);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}