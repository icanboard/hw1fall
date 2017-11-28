using Homework_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework_8.Controllers
{
    public class ArtistsController : Controller
    {
        private ArtistsContext db = new ArtistsContext();

        // GET: Artists
        public ActionResult Index()
        {
            return View();
        }

        // GET: Artists
        public ActionResult Artists()
        {
            var artists = db.ARTISTS;
            return View(artists);
        }

        // GET: Artists
        public ActionResult Artworks()
        {
            var artworks = db.ARTWORKS;
            return View(artworks);
        }

        // GET: Artists
        public ActionResult Classifications()
        {
            var classifications = db.CLASSIFICATIONS;
            return View(classifications);
        }

        // GET: Artists/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
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

        // GET: Artists/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Artists/Edit/5
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

        // GET: Artists/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Artists/Delete/5
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
