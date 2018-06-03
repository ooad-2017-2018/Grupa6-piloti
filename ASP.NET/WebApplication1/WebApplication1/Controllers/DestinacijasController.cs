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
    public class DestinacijasController : Controller
    {
        private OOADContext db = new OOADContext();

        // GET: Destinacijas
        public ActionResult Index()
        {
            return View(db.Destinacija.ToList());
        }

        // GET: Destinacijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destinacija destinacija = db.Destinacija.Find(id);
            if (destinacija == null)
            {
                return HttpNotFound();
            }
            return View(destinacija);
        }

        // GET: Destinacijas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destinacijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DestinacijaId,Naziv")] Destinacija destinacija)
        {
            if (ModelState.IsValid)
            {
                db.Destinacija.Add(destinacija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destinacija);
        }

        // GET: Destinacijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destinacija destinacija = db.Destinacija.Find(id);
            if (destinacija == null)
            {
                return HttpNotFound();
            }
            return View(destinacija);
        }

        // POST: Destinacijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DestinacijaId,Naziv")] Destinacija destinacija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destinacija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destinacija);
        }

        // GET: Destinacijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destinacija destinacija = db.Destinacija.Find(id);
            if (destinacija == null)
            {
                return HttpNotFound();
            }
            return View(destinacija);
        }

        // POST: Destinacijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destinacija destinacija = db.Destinacija.Find(id);
            db.Destinacija.Remove(destinacija);
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
