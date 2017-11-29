using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework6.Models;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Diagnostics;
//using Homework6.DAL;

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

        public ViewResult Products(string category)
        {
            //string ProductName = subCategory;

            var ProductCategory = db.Product.Where(n => n.ProductSubcategory.Name == category);

            //if (category == "Bikes" ||category == null)
            //{
            //    ViewBag.ProductType = "All " + category ;
            //    return View(ProductNames.ToList());
            //}

            return View(ProductCategory.ToList());

        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}