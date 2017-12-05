using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework8.Models;

namespace Homework8.Controllers
{
    public class ClassificationsController : Controller
    {
        private ArtWorksContext db = new ArtWorksContext();

        // GET: Classifications
        public ActionResult Index()
        {
            var classifications = db.Classifications.Include(c => c.Artwork).Include(c => c.Genre);
            return View(classifications.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
