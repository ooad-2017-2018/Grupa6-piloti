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
    public class LinijasController : Controller
    {
        private OOADContext db = new OOADContext();

        // GET: Linijas
        public ActionResult Index()
        {
            var linija = db.Linija.Include(l => l.Aviokompanija).Include(l => l.Dan).Include(l => l.Destinacija);
            return View(linija.ToList());
        }

        // GET: Linijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linija linija = db.Linija.Find(id);
            if (linija == null)
            {
                return HttpNotFound();
            }
            return View(linija);
        }

        // GET: Linijas/Create
        public ActionResult Create()
        {
            ViewBag.AviokompanijaId = new SelectList(db.Aviokompanija, "AviokompanijaId", "Naziv");
            ViewBag.DanId = new SelectList(db.Dan, "DanId", "Naziv");
            ViewBag.DestinacijaId = new SelectList(db.Destinacija, "DestinacijaId", "Naziv");
            return View();
        }

        // POST: Linijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LinijaId,DanId,VrijemePolaska,AviokompanijaId,DestinacijaId,TrajanjeLeta,Cijena")] Linija linija)
        {
            if (ModelState.IsValid)
            {
                db.Linija.Add(linija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AviokompanijaId = new SelectList(db.Aviokompanija, "AviokompanijaId", "Naziv", linija.AviokompanijaId);
            ViewBag.DanId = new SelectList(db.Dan, "DanId", "Naziv", linija.DanId);
            ViewBag.DestinacijaId = new SelectList(db.Destinacija, "DestinacijaId", "Naziv", linija.DestinacijaId);
            return View(linija);
        }

        // GET: Linijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linija linija = db.Linija.Find(id);
            if (linija == null)
            {
                return HttpNotFound();
            }
            ViewBag.AviokompanijaId = new SelectList(db.Aviokompanija, "AviokompanijaId", "Naziv", linija.AviokompanijaId);
            ViewBag.DanId = new SelectList(db.Dan, "DanId", "Naziv", linija.DanId);
            ViewBag.DestinacijaId = new SelectList(db.Destinacija, "DestinacijaId", "Naziv", linija.DestinacijaId);
            return View(linija);
        }

        // POST: Linijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LinijaId,DanId,VrijemePolaska,AviokompanijaId,DestinacijaId,TrajanjeLeta,Cijena")] Linija linija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(linija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AviokompanijaId = new SelectList(db.Aviokompanija, "AviokompanijaId", "Naziv", linija.AviokompanijaId);
            ViewBag.DanId = new SelectList(db.Dan, "DanId", "Naziv", linija.DanId);
            ViewBag.DestinacijaId = new SelectList(db.Destinacija, "DestinacijaId", "Naziv", linija.DestinacijaId);
            return View(linija);
        }

        // GET: Linijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linija linija = db.Linija.Find(id);
            if (linija == null)
            {
                return HttpNotFound();
            }
            return View(linija);
        }

        // POST: Linijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Linija linija = db.Linija.Find(id);
            db.Linija.Remove(linija);
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
