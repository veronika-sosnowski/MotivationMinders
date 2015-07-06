using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotivationMinders.Controllers
{
    public class AdminController : Controller
    {
        private mainDBEntities db = new mainDBEntities();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View(db.SystemUsers.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(string Email = null)
        {
            SystemUser systemuser = db.SystemUsers.Find(Email);
            if (systemuser == null)
            {
                return HttpNotFound();
            }
            return View(systemuser);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(string Email)
        {
            SystemUser systemuser = db.SystemUsers.Find(Email);
            if (systemuser == null)
            {
                return HttpNotFound();
            }
            return View(systemuser);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(SystemUser systemuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(systemuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(systemuser);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(string Email = null)
        {
            SystemUser systemuser = db.SystemUsers.Find(Email);
            if (systemuser == null)
            {
                return HttpNotFound();
            }
            return View(systemuser);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string Email)
        {
            SystemUser systemuser = db.SystemUsers.Find(Email);
            db.SystemUsers.Remove(systemuser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}