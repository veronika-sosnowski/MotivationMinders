using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MotivationMinders.Models;

namespace MotivationMinders.Controllers
{
    public class ProductTagsController : Controller
    {
        private MMEntitiesContext db = new MMEntitiesContext();

        // GET: ProductTags
        public ActionResult Index()
        {
            var productTags = db.ProductTags.Include(p => p.product);
            return View(productTags.ToList());
        }

        // GET: ProductTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTag productTag = db.ProductTags.Find(id);
            if (productTag == null)
            {
                return HttpNotFound();
            }
            return View(productTag);
        }

        // GET: ProductTags/Create
        public ActionResult Create()
        {
            ViewBag.productId = new SelectList(db.products, "productID", "name");
            return View();
        }

        // POST: ProductTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductTagId,productId,tag")] ProductTag productTag)
        {
            if (ModelState.IsValid)
            {
                db.ProductTags.Add(productTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.productId = new SelectList(db.products, "productID", "name", productTag.productId);
            return View(productTag);
        }

        // GET: ProductTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTag productTag = db.ProductTags.Find(id);
            if (productTag == null)
            {
                return HttpNotFound();
            }
            ViewBag.productId = new SelectList(db.products, "productID", "name", productTag.productId);
            return View(productTag);
        }

        // POST: ProductTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductTagId,productId,tag")] ProductTag productTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productId = new SelectList(db.products, "productID", "name", productTag.productId);
            return View(productTag);
        }

        // GET: ProductTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTag productTag = db.ProductTags.Find(id);
            if (productTag == null)
            {
                return HttpNotFound();
            }
            return View(productTag);
        }

        // POST: ProductTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductTag productTag = db.ProductTags.Find(id);
            db.ProductTags.Remove(productTag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
