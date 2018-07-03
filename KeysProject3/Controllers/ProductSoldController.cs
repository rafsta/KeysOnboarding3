using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeysProject3.Controllers
{
    public class ProductSoldController : Controller
    {
        // GET: ProductSold
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductSold/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductSold/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductSold/Create
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

        // GET: ProductSold/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductSold/Edit/5
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

        // GET: ProductSold/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductSold/Delete/5
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
