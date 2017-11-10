using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework5.Models;
using Homework5.DAL;

namespace Homework5.Controllers
{
    public class FormController : Controller
    {
        private AddressContext db = new AddressContext();

        // GET: Form
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Address()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Address([Bind(Include = "FirstName, MiddleName, LastName, DOB, Addr, City, USState, Zip, County")]Address address)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Requests");
            }
            return View();
        }
        public ActionResult Requests()
        {
            return View(db.Addresses.ToList());
        }
    }
}