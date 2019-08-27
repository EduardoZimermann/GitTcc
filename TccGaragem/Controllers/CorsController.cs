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
using TccGaragem.Models;

namespace TccGaragem.Controllers
{
    public class CorsController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/Cors
        public IQueryable<Cor> GetCors()
        {
            return db.Cors;
        }

        // GET: api/Cors/5
        [ResponseType(typeof(Cor))]
        public async Task<IHttpActionResult> GetCor(int id)
        {
            Cor cor = await db.Cors.FindAsync(id);
            if (cor == null)
            {
                return NotFound();
            }

            return Ok(cor);
        }

        // PUT: api/Cors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCor(int id, Cor cor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cor.Id)
            {
                return BadRequest();
            }

            db.Entry(cor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorExists(id))
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

        // POST: api/Cors
        [ResponseType(typeof(Cor))]
        public async Task<IHttpActionResult> PostCor(Cor cor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cors.Add(cor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cor.Id }, cor);
        }

        // DELETE: api/Cors/5
        [ResponseType(typeof(Cor))]
        public async Task<IHttpActionResult> DeleteCor(int id)
        {
            Cor cor = await db.Cors.FindAsync(id);
            if (cor == null)
            {
                return NotFound();
            }

            db.Cors.Remove(cor);
            await db.SaveChangesAsync();

            return Ok(cor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CorExists(int id)
        {
            return db.Cors.Count(e => e.Id == id) > 0;
        }
    }
}