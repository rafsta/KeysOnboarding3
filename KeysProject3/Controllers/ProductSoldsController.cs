using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeysProject3.Controllers
{
    public class ProductSoldsController : Controller
    {
        // GET: ProductSold
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductSolds/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductSolds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductSolds/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductSolds/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductSolds/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductSolds/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductSolds/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
