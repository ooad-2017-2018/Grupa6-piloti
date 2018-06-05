using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebServis.Models;

namespace WebServis.Controllers
{
    public class KartasController : ApiController
    {
        private OOADModel db = new OOADModel();

        // GET: api/Kartas
        public IQueryable<Karta> GetKarta()
        {
            return db.Karta;
        }

        // GET: api/Kartas/5
        [ResponseType(typeof(Karta))]
        public async Task<IHttpActionResult> GetKarta(int id)
        {
            Karta karta = await db.Karta.FindAsync(id);
            if (karta == null)
            {
                return NotFound();
            }

            return Ok(karta);
        }

        // PUT: api/Kartas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKarta(int id, Karta karta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != karta.KartaId)
            {
                return BadRequest();
            }

            db.Entry(karta).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KartaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Kartas
        [ResponseType(typeof(Karta))]
        public async Task<IHttpActionResult> PostKarta(Karta karta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Karta.Add(karta);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = karta.KartaId }, karta);
        }

        // DELETE: api/Kartas/5
        [ResponseType(typeof(Karta))]
        public async Task<IHttpActionResult> DeleteKarta(int id)
        {
            Karta karta = await db.Karta.FindAsync(id);
            if (karta == null)
            {
                return NotFound();
            }

            db.Karta.Remove(karta);
            await db.SaveChangesAsync();

            return Ok(karta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KartaExists(int id)
        {
            return db.Karta.Count(e => e.KartaId == id) > 0;
        }
    }
}