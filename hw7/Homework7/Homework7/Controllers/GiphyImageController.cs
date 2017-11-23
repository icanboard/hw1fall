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
        // GET: /GiphyImage
        // GET: /GiphyImage/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}