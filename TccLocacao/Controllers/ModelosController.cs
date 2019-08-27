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
    public class ModeloesController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/Modeloes
        public IQueryable<Modelo> GetModelos()
        {
            return db.Modelos.Where(x => x.Ativo == true);
        }

        // GET: api/Modeloes/5
        public IQueryable<Modelo> GetModelo(int codigoMarca)
        {
            return db.Modelos.Where(x => x.Marca.CodigoMarca == codigoMarca);
        }

        /*public async Task<IHttpActionResult> GetModelo(int id)
        {
            Modelo modelo = await db.Modelos.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }

            return Ok(modelo);
        }*/

        // PUT: api/Modeloes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutModelo(int id, Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelo.Id)
            {
                return BadRequest();
            }

            db.Entry(modelo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(id))
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

        // POST: api/Modeloes
        [ResponseType(typeof(Modelo))]
        public async Task<IHttpActionResult> PostModelo(Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Modelos.Add(modelo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = modelo.Id }, modelo);
        }

        // DELETE: api/Modeloes/5
        [ResponseType(typeof(Modelo))]
        public async Task<IHttpActionResult> DeleteModelo(int id)
        {
            Modelo modelo = await db.Modelos.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }

            db.Modelos.Find(id).Ativo = false;
            await db.SaveChangesAsync();

            return Ok(modelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModeloExists(int id)
        {
            return db.Modelos.Count(e => e.Id == id) > 0;
        }
    }
}