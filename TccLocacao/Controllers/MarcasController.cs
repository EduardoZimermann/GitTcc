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
using TccLocacao.Models;

namespace TccLocacao.Controllers
{
    public class MarcasController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/Marcas
        public IQueryable<Marca> GetMarcas()
        {
            return db.Marcas.Where(x => x.Ativo == true);
        }

        // GET: api/Marcas/5
        public IQueryable<Marca> GetMarca(int codigoTipo)
        {
            return db.Marcas.Where(x => x.TipoVeiculo.CodigoTipo == codigoTipo);
        }

        /*public async Task<IHttpActionResult> GetMarca(int id)
        {
            Marca marca = await db.Marcas.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            return Ok(marca);
        }*/

        // PUT: api/Marcas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMarca(int id, Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marca.Id)
            {
                return BadRequest();
            }

            db.Entry(marca).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(id))
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

        // POST: api/Marcas
        [ResponseType(typeof(Marca))]
        public async Task<IHttpActionResult> PostMarca(Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Marcas.Add(marca);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = marca.Id }, marca);
        }

        // DELETE: api/Marcas/5
        [ResponseType(typeof(Marca))]
        public async Task<IHttpActionResult> DeleteMarca(int id)
        {
            Marca marca = await db.Marcas.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            db.Marcas.Find(id).Ativo = false;
            await db.SaveChangesAsync();

            return Ok(marca);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarcaExists(int id)
        {
            return db.Marcas.Count(e => e.Id == id) > 0;
        }
    }
}