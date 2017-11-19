using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework7.Controllers
{
    public class GiphyImageController : Controller
    {
        // GET: GiphyImage
        public ActionResult Index()
        {
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];
            Debug.WriteLine("API key = " + apiKey);

            ViewBag.apiKey = apiKey; // allow Index to access apiKey

            return View();
        }
    }
}