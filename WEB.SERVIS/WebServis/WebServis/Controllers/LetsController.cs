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
    public class LetsController : ApiController
    {
        private OOADModel db = new OOADModel();

        // GET: api/Lets
        public IQueryable<Let> GetLet()
        {
            return db.Let;
        }

        // GET: api/Lets/5
        [ResponseType(typeof(Let))]
        public async Task<IHttpActionResult> GetLet(int id)
        {
            Let let = await db.Let.FindAsync(id);
            if (let == null)
            {
                return NotFound();
            }

            return Ok(let);
        }

        // PUT: api/Lets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLet(int id, Let let)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != let.LetId)
            {
                return BadRequest();
            }

            db.Entry(let).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LetExists(id))
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

        // POST: api/Lets
        [ResponseType(typeof(Let))]
        public async Task<IHttpActionResult> PostLet(Let let)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Let.Add(let);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = let.LetId }, let);
        }

        // DELETE: api/Lets/5
        [ResponseType(typeof(Let))]
        public async Task<IHttpActionResult> DeleteLet(int id)
        {
            Let let = await db.Let.FindAsync(id);
            if (let == null)
            {
                return NotFound();
            }

            db.Let.Remove(let);
            await db.SaveChangesAsync();

            return Ok(let);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LetExists(int id)
        {
            return db.Let.Count(e => e.LetId == id) > 0;
        }
    }
}