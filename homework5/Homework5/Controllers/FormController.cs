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

        public ActionResult Address()
        {
            return View();
        }

        public ActionResult Requests()
        {
            return View(db.Addresses.ToList());
        }
    }
}