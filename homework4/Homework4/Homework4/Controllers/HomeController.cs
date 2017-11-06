using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>
        /// The home page of the site.
        /// </summary>
        /// <returns>Website view</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Page 1 contains a bad password maker.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Page1()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Page1")]
        public ActionResult Result1()
        {
            double measure = Convert.ToDouble(Request.Form["measure"]);
            string unit = Request.Form["unit"];
            //double result;

            return Content($"The result is:{unit}");
        }



        public ActionResult Page2()
        {
            return View();
        }
    }
}