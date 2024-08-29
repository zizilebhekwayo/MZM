using Microsoft.AspNet.Identity;
using MZM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MZM.Controllers
{
    public class ShoppingController : Controller
    {
        private Cart_Service cart_Service;
        private Item_Service item_Service;

        Cart_Service cartService = new Cart_Service();

        private ApplicationDbContext db = new ApplicationDbContext();

        private Department_Service department_Service;

        public ShoppingController()
        {
            this.cart_Service = new Cart_Service();
            this.item_Service = new Item_Service();

            this.department_Service = new Department_Service();
        }


        public ActionResult Index(int? id)
        {
            var items_results = new List<Item>();
            try
            {
                if (id != null)
                {
                    if (id == 0)
                    {
                        items_results = item_Service.GetItems().OrderByDescending(x => x.MyDate).ToList();
                        ViewBag.Department = "All Departments";
                    }
                    else
                    {
                        items_results = item_Service.GetItems().Where(x => x.Department.Department_ID == (int)id).OrderByDescending(x => x.MyDate).ToList();
                        ViewBag.Department = department_Service.GetDepartment(id).Department_Name;
                    }
                }
                else
                {
                    items_results = item_Service.GetItems().OrderByDescending(x => x.MyDate).ToList();
                    ViewBag.Department = "All Departments";
                }
            }
            catch (Exception ex) { }
            return View(items_results);
        }
        public ActionResult add_to_cart(int id)
        {
            var UserName = User.Identity.GetUserName();
            var guest = db.Customers.Where(b => b.Email == UserName).FirstOrDefault();



            if (guest == null)
            {
                TempData["ErrorMessage"] = "You cannot add product to cart without logging in.";
            }
            string Email = guest.Email;
            string Name = guest.FirstName;
            string Surname = guest.LastName;
            string Mobile = guest.ContactNo;
            //string BookRef = booked.RefNum;
            int qty = 1;
            var item = item_Service.GetItem(id);
            Cart_Item ct = new Cart_Item();
            if (item != null)
            {
                cart_Service.AddItemToCart(id, Email, Name, Surname, Mobile);
                TempData["Success123"] = "You just added item to your cart!";
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Not_Found", "Error");
        }

        public ActionResult remove_from_cart(string id)
        {
            var item = cart_Service.GetCartItems().FirstOrDefault(x => x.cart_item_id == id);
            if (item != null)
            {
                cart_Service.RemoveItemFromCart(id: id);
                return RedirectToAction("ShoppingCart");
            }
            else
                return RedirectToAction("Not_Found", "Error");
        }
        public ActionResult ShoppingCart()
        {
            ViewBag.Total = cart_Service.GetCartTotal(cart_Service.GetCartID());
            ViewBag.TotalQTY = cart_Service.GetCartItems().FindAll(x => x.cart_id == cart_Service.GetCartID()).Sum(q => q.quantity);
            return View(cart_Service.GetCartItems().FindAll(x => x.cart_id == cart_Service.GetCartID()));
        }
        [HttpPost]
        public ActionResult ShoppingRequest()
        {
            ViewBag.Total = cart_Service.GetCartTotal(cart_Service.GetCartID());
            ViewBag.TotalQTY = cart_Service.GetCartItems().FindAll(x => x.cart_id == cart_Service.GetCartID()).Sum(q => q.quantity);
            return View(cart_Service.GetCartItems().FindAll(x => x.cart_id == cart_Service.GetCartID()));
        }
        [HttpPost]
        public ActionResult countCartItems()
        {
            var username = User.Identity.GetUserName();
            int qty = cart_Service.GetCartItems().Sum(x => x.quantity);
            return Content(qty.ToString());
        }
        public ActionResult Checkout(string id)
        {
            var item = cart_Service.GetCartItems().FirstOrDefault(x => x.cart_item_id == id);

            if (cart_Service.GetCartItems().Count == 0)
            {
                ViewBag.Err = "Opps... you should have atleat one cart item, please shop a few items";
                return RedirectToAction("Index");
            }
            else if (item != null)
            {
                cart_Service.RemoveItemFromCart(id: id);
                return RedirectToAction("ShoppingCart");
            }

            return RedirectToAction("Index", "GameOrders");
        }

        [Authorize]
        public ActionResult HowToGetMyOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HowToGetMyOrder(string street_number, string street_name, string City, string State, string ZipCode, string Country)
        {
            Session["street_number"] = street_number;
            Session["street_name"] = street_name;
            Session["City"] = City;
            Session["State"] = State;
            Session["ZipCode"] = ZipCode;
            Session["Country"] = Country;
            return RedirectToAction("PlaceOrder", new { id = "deliver" });
        }
    }
}