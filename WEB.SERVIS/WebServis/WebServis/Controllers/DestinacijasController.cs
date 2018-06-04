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
    public class DestinacijasController : ApiController
    {
        private OOADModel db = new OOADModel();

        // GET: api/Destinacijas
        public IQueryable<Destinacija> GetDestinacija()
        {
            return db.Destinacija;
        }

        // GET: api/Destinacijas/5
        [ResponseType(typeof(Destinacija))]
        public async Task<IHttpActionResult> GetDestinacija(int id)
        {
            Destinacija destinacija = await db.Destinacija.FindAsync(id);
            if (destinacija == null)
            {
                return NotFound();
            }

            return Ok(destinacija);
        }

        // PUT: api/Destinacijas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDestinacija(int id, Destinacija destinacija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != destinacija.DestinacijaId)
            {
                return BadRequest();
            }

            db.Entry(destinacija).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinacijaExists(id))
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

        // POST: api/Destinacijas
        [ResponseType(typeof(Destinacija))]
        public async Task<IHttpActionResult> PostDestinacija(Destinacija destinacija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Destinacija.Add(destinacija);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = destinacija.DestinacijaId }, destinacija);
        }

        // DELETE: api/Destinacijas/5
        [ResponseType(typeof(Destinacija))]
        public async Task<IHttpActionResult> DeleteDestinacija(int id)
        {
            Destinacija destinacija = await db.Destinacija.FindAsync(id);
            if (destinacija == null)
            {
                return NotFound();
            }

            db.Destinacija.Remove(destinacija);
            await db.SaveChangesAsync();

            return Ok(destinacija);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DestinacijaExists(int id)
        {
            return db.Destinacija.Count(e => e.DestinacijaId == id) > 0;
        }
    }
}