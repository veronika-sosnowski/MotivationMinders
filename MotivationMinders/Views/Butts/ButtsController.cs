using MotivationMinders.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotivationMinders.Views.Butts
{
    public class ButtsController : Controller
    {
        // GET: Butts
        public ActionResult Index()
        {
            var test = db.AspNetUsers.ToList();
            return View(test);
        }
        public ActionResult editRole()
        {
            return View();
        }

        private Entities db = new Entities();
        public ActionResult Roles()
        {
           
            return View();
        }

    }
}