﻿using System;
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
    public class ArtworksController : Controller
    {
        private ArtWorksContext db = new ArtWorksContext();

        // GET: Artworks
        public ActionResult Index()
        {
            var artworks = db.Artworks.Include(a => a.Artist);
            return View(artworks.ToList());
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
