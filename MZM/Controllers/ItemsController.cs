using MZM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MZM.Controllers
{
    public class ItemsController : Controller
    {
        private Item_Service item;
        private ApplicationDbContext db = new ApplicationDbContext();

        Department_Service category_Service;

        public ItemsController()
        {
            this.item = new Item_Service();
            this.category_Service = new Department_Service();
        }
        public ActionResult Index()
        {
            return View(item.GetItems());
        }
        public ActionResult Details(int? id)
        {

            // Example: 2:30 PM
            if (id == null)
                return RedirectToAction("Bad_Request", "Error");
            if (item.GetItem(id) != null)
                return View(item.GetItem(id));
            else
                return RedirectToAction("Not_Found", "Error");

        }

        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.Department_ID = new SelectList(category_Service.GetDepartments(), "Department_ID", "Department_Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item model, HttpPostedFileBase img_upload)
        {

            ViewBag.Department_ID = new SelectList(category_Service.GetDepartments(), "Department_ID", "Department_Name");
            byte[] data = null;
            data = new byte[img_upload.ContentLength];
            img_upload.InputStream.Read(data, 0, img_upload.ContentLength);
            model.Picture = data;
            model.MyDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                item.AddItem(model);
                return RedirectToAction("Index");
            }

            return View(model);

        }
        public ActionResult Edit(int? id)
        {
            ViewBag.Department_ID = new SelectList(category_Service.GetDepartments(), "Department_ID", "Department_Name");
            if (id == null)
                return RedirectToAction("Bad_Request", "Error");
            if (item.GetItem(id) != null)
                return View(item.GetItem(id));
            else
                return RedirectToAction("Not_Found", "Error");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item model, HttpPostedFileBase img_upload)
        {
            byte[] data = null;
            data = new byte[img_upload.ContentLength];
            img_upload.InputStream.Read(data, 0, img_upload.ContentLength);
            model.Picture = data;
            if (ModelState.IsValid)
            {
                item.UpdateItem(model);
                return RedirectToAction("Index");
            }
            ViewBag.Department_ID = new SelectList(category_Service.GetDepartments(), "Department_ID", "Department_Name");
            return View(model);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Bad_Request", "Error");
            if (item.GetItem(id) != null)
                return View(item.GetItem(id));
            else
                return RedirectToAction("Not_Found", "Error");
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            item.RemoveItem(item.GetItem(id));
            return RedirectToAction("Index");
        }

        //Statistics below

        public ActionResult ItemStats()
        {
            return View();
        }
    }
}