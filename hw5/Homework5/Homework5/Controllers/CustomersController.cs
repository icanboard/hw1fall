using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework5.DAL;
using Homework5.Models;


namespace Homework5.Controllers
{
    public class CustomersController : Controller 
    {
        private CustomerContext db = new CustomerContext(); //allows me to call the db and get results
        
        // GET: Customers
        // GET: Customers/Index
        public ActionResult Index()
        {
            return View(db.Customers.ToList()); //This must be passed for the view to display the custoemrs
        }

        // GET: CreateCustomer
        [HttpGet]
        public ActionResult CreateCustomer()
        {
            
            return View();
        }

        // POST: CreateCustomer
        [HttpPost]
        public ActionResult CreateCustomer(int ODL)
        {
            ViewBag.RequestMethod = "POST";
            ViewBag.ODL = ODL;
            
            return RedirectToAction("SubmissionSuccessful"); //Redirect to SubmissionSuccessful
        }

        // GET: SubmissionSuccessful
        [HttpGet]
        public ActionResult SubmissionSuccessful()
        {
            return View();
        }
    }
}