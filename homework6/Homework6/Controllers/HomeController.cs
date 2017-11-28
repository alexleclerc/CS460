using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework6.Models;
using System.Data;
using System.Data.Entity;

namespace Homework6.Controllers
{
    public class HomeController : Controller
    {
        //create a new instance of the Context class
        AdventureWorksContext db = new AdventureWorksContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}