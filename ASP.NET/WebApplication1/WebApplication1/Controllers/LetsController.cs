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
    public class LetsController : Controller
    {
        private OOADContext db = new OOADContext();

        // GET: Lets
        public ActionResult Index()
        {
            var let = db.Let.Include(l => l.Linija).Include(l => l.Status);
            return View(let.ToList());
        }

        // GET: Lets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Let let = db.Let.Find(id);
            if (let == null)
            {
                return HttpNotFound();
            }
            return View(let);
        }

        // GET: Lets/Create
        public ActionResult Create()
        {
            ViewBag.LinijaId = new SelectList(db.Linija, "LinijaId", "LinijaId");
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Naziv");
            return View();
        }

        // POST: Lets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LetId,DatumiVrijeme,StatusId,LinijaId")] Let let)
        {
            if (ModelState.IsValid)
            {
                db.Let.Add(let);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LinijaId = new SelectList(db.Linija, "LinijaId", "LinijaId", let.LinijaId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Naziv", let.StatusId);
            return View(let);
        }

        // GET: Lets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Let let = db.Let.Find(id);
            if (let == null)
            {
                return HttpNotFound();
            }
            ViewBag.LinijaId = new SelectList(db.Linija, "LinijaId", "LinijaId", let.LinijaId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Naziv", let.StatusId);
            return View(let);
        }

        // POST: Lets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LetId,DatumiVrijeme,StatusId,LinijaId")] Let let)
        {
            if (ModelState.IsValid)
            {
                db.Entry(let).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LinijaId = new SelectList(db.Linija, "LinijaId", "LinijaId", let.LinijaId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Naziv", let.StatusId);
            return View(let);
        }

        // GET: Lets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Let let = db.Let.Find(id);
            if (let == null)
            {
                return HttpNotFound();
            }
            return View(let);
        }

        // POST: Lets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Let let = db.Let.Find(id);
            db.Let.Remove(let);
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
