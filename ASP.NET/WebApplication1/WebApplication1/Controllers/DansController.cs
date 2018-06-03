using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DansController : Controller
    {
        private OOADContext db = new OOADContext();

        // GET: Dans
        public ActionResult Index()
        {
            return View(db.Dan.ToList());
        }

        // GET: Dans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dan dan = db.Dan.Find(id);
            if (dan == null)
            {
                return HttpNotFound();
            }
            return View(dan);
        }

        // GET: Dans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DanId,Naziv")] Dan dan)
        {
            if (ModelState.IsValid)
            {
                db.Dan.Add(dan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dan);
        }

        // GET: Dans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dan dan = db.Dan.Find(id);
            if (dan == null)
            {
                return HttpNotFound();
            }
            return View(dan);
        }

        // POST: Dans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DanId,Naziv")] Dan dan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dan);
        }

        // GET: Dans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dan dan = db.Dan.Find(id);
            if (dan == null)
            {
                return HttpNotFound();
            }
            return View(dan);
        }

        // POST: Dans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dan dan = db.Dan.Find(id);
            db.Dan.Remove(dan);
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
