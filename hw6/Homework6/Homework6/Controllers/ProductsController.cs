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

            var photo = (from item in db.ProductPhotoes
                         where item.ProductProductPhotoes.Any(p => p.ProductID == id)
                         select item.LargePhoto).FirstOrDefault();
            
            ViewBag.pPhoto = photo;

            return View(product);
        }
        
        
        // POST: ~/Products/Product
        // this request comes after submitting the add review form
        [HttpPost]
        public ActionResult Product(int? id, string name, string email, int? rating, string comments)
        {
            // create a new ProductReview object
            ProductReview review = db.ProductReviews.Create();
            
            if(id == null || id.Equals("") || name == null || name.Equals("") || email == null || email.Equals("") || rating == null || rating.Equals("") || comments == null || comments.Equals(""))
            {
                return RedirectToAction("Failure");
            }

            // add all the attributes of a Product Review to add it to the db
            review.Comments = comments;
            review.EmailAddress = email;
            review.ModifiedDate = DateTime.Now; // correct date/time format
            review.ProductID = (int)id;
            review.Rating = (int)rating;
            review.ReviewDate= DateTime.Now;
            review.ReviewerName = name;

            if (ModelState.IsValid)
            {
                db.ProductReviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Success");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Failure()
        {
            return View();
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}