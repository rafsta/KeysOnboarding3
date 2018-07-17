using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using KeysProject3.Models;

namespace KeysProject3.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private readonly MVC3Entities db;
        public ProductsController()
        {
            db = new MVC3Entities();
        }

        // GET: api/Products
        public IEnumerable<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        // GET: api/Products/id
        [ResponseType(typeof(Product))]
        public Product GetProduct(int id)
        {
            Product product = db.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return product;
        }

        // POST: api/Products
        [HttpPost]
        [ResponseType(typeof(Product))]
        public Product CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            db.Products.Add(product);
            db.SaveChanges();

            return product;
        }


        // PUT: api/Products/id
        [HttpPut]
        [ResponseType(typeof(void))]
        public void PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var productInDb = db.Products.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            productInDb.Name = product.Name;
            productInDb.Price = product.Price;

            db.SaveChanges();
        }


        // DELETE: api/Products/id
        [HttpDelete]
        [ResponseType(typeof(Product))]
        public void DeleteProduct(int id)
        {
            Product product = db.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Products.Remove(product);
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

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}