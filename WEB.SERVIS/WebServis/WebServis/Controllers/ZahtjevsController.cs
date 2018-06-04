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
    public class ZahtjevsController : ApiController
    {
        private OOADModel db = new OOADModel();

        // GET: api/Zahtjevs
        public IQueryable<Zahtjev> GetZahtjev()
        {
            return db.Zahtjev;
        }

        // GET: api/Zahtjevs/5
        [ResponseType(typeof(Zahtjev))]
        public async Task<IHttpActionResult> GetZahtjev(int id)
        {
            Zahtjev zahtjev = await db.Zahtjev.FindAsync(id);
            if (zahtjev == null)
            {
                return NotFound();
            }

            return Ok(zahtjev);
        }

        // PUT: api/Zahtjevs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutZahtjev(int id, Zahtjev zahtjev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zahtjev.ZahtjevId)
            {
                return BadRequest();
            }

            db.Entry(zahtjev).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZahtjevExists(id))
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

        // POST: api/Zahtjevs
        [ResponseType(typeof(Zahtjev))]
        public async Task<IHttpActionResult> PostZahtjev(Zahtjev zahtjev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zahtjev.Add(zahtjev);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = zahtjev.ZahtjevId }, zahtjev);
        }

        // DELETE: api/Zahtjevs/5
        [ResponseType(typeof(Zahtjev))]
        public async Task<IHttpActionResult> DeleteZahtjev(int id)
        {
            Zahtjev zahtjev = await db.Zahtjev.FindAsync(id);
            if (zahtjev == null)
            {
                return NotFound();
            }

            db.Zahtjev.Remove(zahtjev);
            await db.SaveChangesAsync();

            return Ok(zahtjev);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZahtjevExists(int id)
        {
            return db.Zahtjev.Count(e => e.ZahtjevId == id) > 0;
        }
    }
}