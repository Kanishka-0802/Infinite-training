
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assessment_1.Models;

namespace Assessment_1.Controllers
{
    public class CodeController : Controller
    {
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }
        private NorthwindEntities db = new NorthwindEntities();

        
        public ActionResult CustomersInGermany()
        {
            var customers = db.Customers
                              .Where(c => c.Country == "Germany")
                              .ToList();
            return View(customers);
        }

     
        public ActionResult CustomerByOrder()
        {
            var customer = (from o in db.Orders
                            where o.OrderID == 10248
                            select o.Customer).FirstOrDefault();

            return View(customer);
        }
    }
}
