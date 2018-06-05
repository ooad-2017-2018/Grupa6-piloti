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
    public class DansController : ApiController
    {
        private OOADModel db = new OOADModel();

        // GET: api/Dans
        public IQueryable<Dan> GetDan()
        {
            return db.Dan;
        }

        // GET: api/Dans/5
        [ResponseType(typeof(Dan))]
        public async Task<IHttpActionResult> GetDan(int id)
        {
            Dan dan = await db.Dan.FindAsync(id);
            if (dan == null)
            {
                return NotFound();
            }

            return Ok(dan);
        }

        // PUT: api/Dans/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDan(int id, Dan dan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dan.DanId)
            {
                return BadRequest();
            }

            db.Entry(dan).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanExists(id))
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

        // POST: api/Dans
        [ResponseType(typeof(Dan))]
        public async Task<IHttpActionResult> PostDan(Dan dan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dan.Add(dan);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dan.DanId }, dan);
        }

        // DELETE: api/Dans/5
        [ResponseType(typeof(Dan))]
        public async Task<IHttpActionResult> DeleteDan(int id)
        {
            Dan dan = await db.Dan.FindAsync(id);
            if (dan == null)
            {
                return NotFound();
            }

            db.Dan.Remove(dan);
            await db.SaveChangesAsync();

            return Ok(dan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DanExists(int id)
        {
            return db.Dan.Count(e => e.DanId == id) > 0;
        }
    }
}