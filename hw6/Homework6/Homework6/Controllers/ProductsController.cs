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

        // GET: ~/Products/
        // GET: ~/Products/Index
        // param id = ProductCategoryID;
        public ActionResult Index(int? id)
        {
            // get all the productcategories (4 of them)
            var categories = db.ProductCategories;
            // if there is a null, it throws an error, so check for nulls; else set to the id for use in view
            if (id != null && db.ProductCategories.Find(id) != null)
            {
                ViewBag.catID = id;
            }
            //return all the categories to iterate and disect
            return View(categories);
        }

        // GET: ~/Products/Products
        // param id = ProductSubcategoryID;
        public ActionResult Products(int? id)
        {
            // if theres a null, it throws an error, so check for nulls
            if (id == null || db.ProductSubcategories.Find(id) == null)
            {
                // if its null, send them back to the index to pick a category
                return RedirectToAction("Index");
            }
            // get all the products that match the product subcategory that was passed in
            var products = db.ProductSubcategories.Find(id).Products.ToList();

            return View(products);
        }

        // GET: ~/Products/Product
        // param id = ProductID;
        public ActionResult Product(int? id)
        {
            // if theres a null, it throws an error, so check for nulls
            if (id == null || db.Products.Find(id) == null)
            {
                // if its null, send them back to the index to pick a category/item
                return RedirectToAction("Index");
            }

            var product = db.Products.Find(id);

            return View(product);
        }
    }
}