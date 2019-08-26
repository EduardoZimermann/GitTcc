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
using LocacaoDeGaragens.Models;

namespace LocacaoDeGaragens.Controllers
{
    public class ModeloAutomovelsController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/ModeloAutomovels
        public IQueryable<ModeloAutomovel> GetModeloAutomovels()
        {
            return db.ModeloAutomovels;
        }

        // GET: api/ModeloAutomovels/5
        [ResponseType(typeof(ModeloAutomovel))]
        public IQueryable<ModeloAutomovel> GetModeloAutomovel(int id)
        {
            return db.ModeloAutomovels.Where(x => x.MarcaFk == id);
        }

        /*// GET: api/ModeloAutomovels/5
        [ResponseType(typeof(ModeloAutomovel))]
        public async Task<IHttpActionResult> GetModeloAutomovel(int id)
        {
            ModeloAutomovel modeloAutomovel = await db.ModeloAutomovels.FindAsync(id);
            if (modeloAutomovel == null)
            {
                return NotFound();
            }

            return Ok(modeloAutomovel);
        }*/

        // PUT: api/ModeloAutomovels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutModeloAutomovel(int id, ModeloAutomovel modeloAutomovel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modeloAutomovel.Id)
            {
                return BadRequest();
            }

            db.Entry(modeloAutomovel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloAutomovelExists(id))
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

        // POST: api/ModeloAutomovels
        [ResponseType(typeof(ModeloAutomovel))]
        public async Task<IHttpActionResult> PostModeloAutomovel(ModeloAutomovel modeloAutomovel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ModeloAutomovels.Add(modeloAutomovel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = modeloAutomovel.Id }, modeloAutomovel);
        }

        // DELETE: api/ModeloAutomovels/5
        [ResponseType(typeof(ModeloAutomovel))]
        public async Task<IHttpActionResult> DeleteModeloAutomovel(int id)
        {
            ModeloAutomovel modeloAutomovel = await db.ModeloAutomovels.FindAsync(id);
            if (modeloAutomovel == null)
            {
                return NotFound();
            }

            db.ModeloAutomovels.Remove(modeloAutomovel);
            await db.SaveChangesAsync();

            return Ok(modeloAutomovel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModeloAutomovelExists(int id)
        {
            return db.ModeloAutomovels.Count(e => e.Id == id) > 0;
        }
    }
}