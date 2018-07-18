using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeysProject3.Models;

namespace KeysProject3.Controllers
{
    public class CustomersController : Controller
    {
        private readonly MVC3Entities db;

        public CustomersController()
        {
            db = new MVC3Entities();
        }


        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }
    }
}
