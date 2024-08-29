using Microsoft.AspNet.Identity;
using MZM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MZM.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Services()
        {

            return View();
        }

        public ActionResult Show()
        {
            return View();
        }
        public ActionResult Radio()
        {

            return View();
        }

        public ActionResult Pictures()
        {
            return View();
        }

        public ActionResult Latest()
        {
            return View();
        }
        public ActionResult Requests()
        {
            if (User.IsInRole("Customer"))
            {

            }
            return View(db.Contacts.ToList());
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        // POST: Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                ViewBag.Message = "Your message has been sent!";
                ModelState.Clear();
            }
            return View();
        }

        public ActionResult Thanks()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }
    }
}