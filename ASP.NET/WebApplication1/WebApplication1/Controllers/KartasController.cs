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
    public class KartasController : Controller
    {
        private OOADContext db = new OOADContext();

        // GET: Kartas
        public ActionResult Index()
        {
            var karta = db.Karta.Include(k => k.Let).Include(k => k.Putnik);
            return View(karta.ToList());
        }

        // GET: Kartas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karta karta = db.Karta.Find(id);
            if (karta == null)
            {
                return HttpNotFound();
            }
            return View(karta);
        }

        // GET: Kartas/Create
        public ActionResult Create()
        {
            ViewBag.LetId = new SelectList(db.Let, "LetId", "LetId");
            ViewBag.PutnikId = new SelectList(db.Putnik, "PutnikId", "Ime");
            return View();
        }

        // POST: Kartas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KartaId,LetId,PutnikId")] Karta karta)
        {
            if (ModelState.IsValid)
            {
                db.Karta.Add(karta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LetId = new SelectList(db.Let, "LetId", "LetId", karta.LetId);
            ViewBag.PutnikId = new SelectList(db.Putnik, "PutnikId", "Ime", karta.PutnikId);
            return View(karta);
        }

        // GET: Kartas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karta karta = db.Karta.Find(id);
            if (karta == null)
            {
                return HttpNotFound();
            }
            ViewBag.LetId = new SelectList(db.Let, "LetId", "LetId", karta.LetId);
            ViewBag.PutnikId = new SelectList(db.Putnik, "PutnikId", "Ime", karta.PutnikId);
            return View(karta);
        }

        // POST: Kartas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KartaId,LetId,PutnikId")] Karta karta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(karta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LetId = new SelectList(db.Let, "LetId", "LetId", karta.LetId);
            ViewBag.PutnikId = new SelectList(db.Putnik, "PutnikId", "Ime", karta.PutnikId);
            return View(karta);
        }

        // GET: Kartas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karta karta = db.Karta.Find(id);
            if (karta == null)
            {
                return HttpNotFound();
            }
            return View(karta);
        }

        // POST: Kartas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Karta karta = db.Karta.Find(id);
            db.Karta.Remove(karta);
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
