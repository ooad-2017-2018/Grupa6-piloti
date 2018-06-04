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
    public class AviokompanijasController : ApiController
    {
        private OOADModel db = new OOADModel();

        // GET: api/Aviokompanijas
        public IQueryable<Aviokompanija> GetAviokompanija()
        {
            return db.Aviokompanija;
        }

        // GET: api/Aviokompanijas/5
        [ResponseType(typeof(Aviokompanija))]
        public async Task<IHttpActionResult> GetAviokompanija(int id)
        {
            Aviokompanija aviokompanija = await db.Aviokompanija.FindAsync(id);
            if (aviokompanija == null)
            {
                return NotFound();
            }

            return Ok(aviokompanija);
        }

        // PUT: api/Aviokompanijas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAviokompanija(int id, Aviokompanija aviokompanija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aviokompanija.AviokompanijaId)
            {
                return BadRequest();
            }

            db.Entry(aviokompanija).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AviokompanijaExists(id))
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

        // POST: api/Aviokompanijas
        [ResponseType(typeof(Aviokompanija))]
        public async Task<IHttpActionResult> PostAviokompanija(Aviokompanija aviokompanija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Aviokompanija.Add(aviokompanija);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aviokompanija.AviokompanijaId }, aviokompanija);
        }

        // DELETE: api/Aviokompanijas/5
        [ResponseType(typeof(Aviokompanija))]
        public async Task<IHttpActionResult> DeleteAviokompanija(int id)
        {
            Aviokompanija aviokompanija = await db.Aviokompanija.FindAsync(id);
            if (aviokompanija == null)
            {
                return NotFound();
            }

            db.Aviokompanija.Remove(aviokompanija);
            await db.SaveChangesAsync();

            return Ok(aviokompanija);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AviokompanijaExists(int id)
        {
            return db.Aviokompanija.Count(e => e.AviokompanijaId == id) > 0;
        }
    }
}