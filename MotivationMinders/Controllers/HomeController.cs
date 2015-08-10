using MotivationMinders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MotivationMinders.Controllers
{
    public class HomeController : Controller
    {
      
        private MMEntitiesContext db = new MMEntitiesContext();
        public ActionResult Index()
        {
            ViewBag.Message = "";
            return View();
        }
        [HttpPost]
        public ActionResult About(string thurp)
        {
            string data = thurp;
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Catalogue()
        {
            ViewBag.Message = "Your catalogue page.";

            return View(db.ProductImages.ToList());
        }

        public ActionResult Product(int? id)
        {
            ViewBag.Message = "Your product page.";
            product product = db.products.Find(id);
            return View(product);
        }
        public ActionResult Build()
        {
            ViewBag.Message = "Your Build page.";

            return View(db.ProductImages.ToList());
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }

        public ActionResult Error404()
        {
            return View();
        }

    }
}