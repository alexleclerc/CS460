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
            double result;
            string convertedunit;

            if (unit.ToUpper() == "MI" || unit.ToUpper() == "MILE")
            {
                //if the input was miles, convert to KM
                result = measure * 1.60934;
                convertedunit = "km";
            }
            else if (unit.ToUpper() == "KM" || unit.ToUpper() == "KILOMETER")
            {
                result = measure * 0.621371;
                convertedunit = "mi";
            }
            else
            {
                return Content($"Please input a number, and a unit (either mi/miles or km/kilometer");
            }
            return Content($"The result is: {result}{convertedunit}");
        }

        


        [HttpGet]
        public ActionResult Page2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Page2(FormCollection pageform)
        {
            string food = pageform["food"];
            int birthyear = Convert.ToInt32(pageform["birthyear"]);
            int year2dig = birthyear % 100;

            string result = food + year2dig;

            ViewBag.genpassword = ($"{result} is the bad password you shouldn't use.");

            return View();
        }
    }
}