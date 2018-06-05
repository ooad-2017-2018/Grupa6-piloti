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
    public class ZahtjevsController : Controller
    {
        private OOADContext db = new OOADContext();

        // GET: Zahtjevs
        public ActionResult Index()
        {
            var zahtjev = db.Zahtjev.Include(z => z.Let);
            return View(zahtjev.ToList());
        }

        // GET: Zahtjevs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zahtjev zahtjev = db.Zahtjev.Find(id);
            if (zahtjev == null)
            {
                return HttpNotFound();
            }
            return View(zahtjev);
        }

        // GET: Zahtjevs/Create
        public ActionResult Create()
        {
            ViewBag.LetId = new SelectList(db.Let, "LetId", "LetId");
            return View();
        }

        // POST: Zahtjevs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZahtjevId,LetId,Razlog,Obradjen,Prihvacen")] Zahtjev zahtjev)
        {
            if (ModelState.IsValid)
            {
                db.Zahtjev.Add(zahtjev);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LetId = new SelectList(db.Let, "LetId", "LetId", zahtjev.LetId);
            return View(zahtjev);
        }

        // GET: Zahtjevs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zahtjev zahtjev = db.Zahtjev.Find(id);
            if (zahtjev == null)
            {
                return HttpNotFound();
            }
            ViewBag.LetId = new SelectList(db.Let, "LetId", "LetId", zahtjev.LetId);
            return View(zahtjev);
        }

        // POST: Zahtjevs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZahtjevId,LetId,Razlog,Obradjen,Prihvacen")] Zahtjev zahtjev)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zahtjev).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LetId = new SelectList(db.Let, "LetId", "LetId", zahtjev.LetId);
            return View(zahtjev);
        }

        // GET: Zahtjevs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zahtjev zahtjev = db.Zahtjev.Find(id);
            if (zahtjev == null)
            {
                return HttpNotFound();
            }
            return View(zahtjev);
        }

        // POST: Zahtjevs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zahtjev zahtjev = db.Zahtjev.Find(id);
            db.Zahtjev.Remove(zahtjev);
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
