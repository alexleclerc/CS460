using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework8.Models;

namespace Homework8.Controllers
{
    public class HomeController : Controller
    {
        private ArtWorksContext db = new ArtWorksContext();

        public ActionResult Index()
        {

            return View(db.Genres.ToList());

        }

        public JsonResult Genre(int id)
        {
            var ArtCollection = db.Genres.Where(g => g.GenreID == id)
                                         .Select(x => x.Classifications)
                                         .FirstOrDefault()
                                         .Select(x => new { x.Artwork.Title, x.Artwork.Artist.FirstName, x.Artwork.Artist.MiddleName, x.Artwork.Artist.LastName })
                                         .OrderBy(x => x.Title)
                                         .ToList();
            //list object 
            return Json(ArtCollection, JsonRequestBehavior.AllowGet);
         }
    }
}