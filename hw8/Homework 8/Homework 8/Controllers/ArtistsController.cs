using Homework_8.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework_8.Controllers
{
    public class ArtistsController : Controller
    {
        private ArtistsContext db = new ArtistsContext();

        // GET: Artists
        // GET: Artists/Index
        public ActionResult Index()
        {
            var genres = db.GENRES;
            return View(genres);
        }

        // GET: Artists/Artists
        public ActionResult Artists()
        {
            var artists = db.ARTISTS;
            return View(artists);
        }

        // GET: Artists/Artworks
        public ActionResult Artworks()
        {
            var artworks = db.ARTWORKS;
            return View(artworks);
        }

        // GET: Artists/Classifications
        public ActionResult Classifications()
        {
            var classifications = db.CLASSIFICATIONS;
            return View(classifications);
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
                ARTIST artist = db.ARTISTS.Create();

                artist.ArtistName = collection["artistName"];
                artist.BirthCity = collection["birthCity"];
                artist.BirthDate = collection["birthDate"];

                db.ARTISTS.Add(artist);
                db.SaveChanges();

                return RedirectToAction("Artists");
            }
            catch
            {
                return View();
            }
        }

        // GET: Artists/Details/5
        public ActionResult Details(int id)
        {
            var artist = db.ARTISTS.Where(a => a.AID == id).FirstOrDefault();
            return View(artist);
        }
        

        // GET: Artists/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.aName = db.ARTISTS.Where(a => a.AID == id).FirstOrDefault().ArtistName;
            ViewBag.aCity = db.ARTISTS.Where(a => a.AID == id).FirstOrDefault().BirthCity;
            ViewBag.aDOB = db.ARTISTS.Where(a => a.AID == id).FirstOrDefault().BirthDate;
            return View();
        }

        // POST: Artists/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var artistToUpdate = db.ARTISTS.Find(id);

                artistToUpdate.ArtistName = collection["artistName"];
                artistToUpdate.BirthCity = collection["birthCity"];
                artistToUpdate.BirthDate = collection["birthDate"];

                db.SaveChanges();

                return RedirectToAction("Details/" + id);
            }
            catch
            {
                return View();
            }
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int id)
        {
            var artist = db.ARTISTS.Where(a => a.AID == id).FirstOrDefault();

            ViewBag.aName = db.ARTISTS.Where(a => a.AID == id).FirstOrDefault().ArtistName;
            ViewBag.aCity = db.ARTISTS.Where(a => a.AID == id).FirstOrDefault().BirthCity;
            ViewBag.aDOB = db.ARTISTS.Where(a => a.AID == id).FirstOrDefault().BirthDate;
            
            return View(artist); 
        }

        // POST: Artists/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var artist = db.ARTISTS.Find(id);

                db.ARTISTS.Remove(artist);
                db.SaveChanges();
                
                return RedirectToAction("Artists");
            }
            catch
            {
                return View();
            }
        }

        //https://stackoverflow.com/questions/25304610/how-to-get-a-list-from-mvc-controller-to-view-using-jquery-ajax
        // POST: Artists/Genre
        [HttpPost]
        public JsonResult Genre(string genre)
        {
            var artwork = db.GENRES.Find(genre).CLASSIFICATIONS.ToList().OrderBy(t => t.ARTWORK.Title).Select(a => new { aw = a.AWID, awa = a.ARTWORK.AID }).ToList();
            string[] artworkCreator = new string[artwork.Count()];
            for (int i = 0; i < artworkCreator.Length; ++i)
            {
                artworkCreator[i] = $"<ul>{db.ARTWORKS.Find(artwork[i].aw).Title} by {db.ARTISTS.Find(artwork[i].awa).ArtistName}</ul>";
            }
            var data = new
            {
                arr = artworkCreator
            };
            
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
