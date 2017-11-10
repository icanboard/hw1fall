using Homework6.Models; // required to add the dbcontext class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework6.Controllers
{
    public class ProductsController : Controller
    {
        private AdventureWorksContext db = new AdventureWorksContext(); // brings in dbcontext
        
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
    }
}