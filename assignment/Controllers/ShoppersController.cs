using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using assignment.Models;

namespace assignment.Controllers
{
    [Authorize]
    public class ShoppersController : Controller
    {
        private Model1 db = new Model1();

        // GET: Shoppers
        public ActionResult Index()
        {
            var shoppers = db.Shoppers.Include(s => s.Shopperss);
            return View(shoppers.ToList());
        }

        // GET: Shoppers/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopper shopper = db.Shoppers.Find(id);
            if (shopper == null)
            {
                return HttpNotFound();
            }
            return View(shopper);
        }

        // GET: Shoppers/Create
        public ActionResult Create()
        {
            ViewBag.Stock = new SelectList(db.Shoppersses, "Price", "Stock");
            return View();
        }

        // POST: Shoppers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stock,Products,Food,Medicine")] Shopper shopper)
        {
            if (ModelState.IsValid)
            {
                db.Shoppers.Add(shopper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Stock = new SelectList(db.Shoppersses, "Price", "Stock", shopper.Stock);
            return View(shopper);
        }

        // GET: Shoppers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopper shopper = db.Shoppers.Find(id);
            if (shopper == null)
            {
                return HttpNotFound();
            }
            ViewBag.Stock = new SelectList(db.Shoppersses, "Price", "Stock", shopper.Stock);
            return View(shopper);
        }

        // POST: Shoppers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stock,Products,Food,Medicine")] Shopper shopper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Stock = new SelectList(db.Shoppersses, "Price", "Stock", shopper.Stock);
            return View(shopper);
        }

        // GET: Shoppers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopper shopper = db.Shoppers.Find(id);
            if (shopper == null)
            {
                return HttpNotFound();
            }
            return View(shopper);
        }

        // POST: Shoppers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shopper shopper = db.Shoppers.Find(id);
            db.Shoppers.Remove(shopper);
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
