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
    public class LinijasController : ApiController
    {
        private OOADModel db = new OOADModel();

        // GET: api/Linijas
        public IQueryable<Linija> GetLinija()
        {
            return db.Linija;
        }

        // GET: api/Linijas/5
        [ResponseType(typeof(Linija))]
        public async Task<IHttpActionResult> GetLinija(int id)
        {
            Linija linija = await db.Linija.FindAsync(id);
            if (linija == null)
            {
                return NotFound();
            }

            return Ok(linija);
        }

        // PUT: api/Linijas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLinija(int id, Linija linija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != linija.LinijaId)
            {
                return BadRequest();
            }

            db.Entry(linija).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinijaExists(id))
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

        // POST: api/Linijas
        [ResponseType(typeof(Linija))]
        public async Task<IHttpActionResult> PostLinija(Linija linija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Linija.Add(linija);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = linija.LinijaId }, linija);
        }

        // DELETE: api/Linijas/5
        [ResponseType(typeof(Linija))]
        public async Task<IHttpActionResult> DeleteLinija(int id)
        {
            Linija linija = await db.Linija.FindAsync(id);
            if (linija == null)
            {
                return NotFound();
            }

            db.Linija.Remove(linija);
            await db.SaveChangesAsync();

            return Ok(linija);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LinijaExists(int id)
        {
            return db.Linija.Count(e => e.LinijaId == id) > 0;
        }
    }
}