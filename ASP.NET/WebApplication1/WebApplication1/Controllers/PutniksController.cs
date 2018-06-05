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
    public class PutniksController : Controller
    {
        private OOADContext db = new OOADContext();

        // GET: Putniks
        public ActionResult Index()
        {
            return View(db.Putnik.ToList());
        }

        // GET: Putniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Putnik putnik = db.Putnik.Find(id);
            if (putnik == null)
            {
                return HttpNotFound();
            }
            return View(putnik);
        }

        // GET: Putniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Putniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PutnikId,Ime,Prezime,DatumRodjenja,Email")] Putnik putnik)
        {
            if (ModelState.IsValid)
            {
                db.Putnik.Add(putnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(putnik);
        }

        // GET: Putniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Putnik putnik = db.Putnik.Find(id);
            if (putnik == null)
            {
                return HttpNotFound();
            }
            return View(putnik);
        }

        // POST: Putniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PutnikId,Ime,Prezime,DatumRodjenja,Email")] Putnik putnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(putnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(putnik);
        }

        // GET: Putniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Putnik putnik = db.Putnik.Find(id);
            if (putnik == null)
            {
                return HttpNotFound();
            }
            return View(putnik);
        }

        // POST: Putniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Putnik putnik = db.Putnik.Find(id);
            db.Putnik.Remove(putnik);
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
