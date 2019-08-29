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
    public class PendenciasController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/Pendencias
        public IQueryable<Pendencia> GetPendencias()
        {
            return db.Pendencias.Where(x => x.Ativo == true);
        }

        // GET: api/Pendencias/5
        [ResponseType(typeof(Pendencia))]
        public async Task<IHttpActionResult> GetPendencia(int id)
        {
            Pendencia pendencia = await db.Pendencias.FindAsync(id);
            if (pendencia == null)
            {
                return NotFound();
            }

            return Ok(pendencia);
        }

        // PUT: api/Pendencias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPendencia(int id, Pendencia pendencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pendencia.Id)
            {
                return BadRequest();
            }

            if (pendencia.Aprovado)
                db.Locacoes.FirstOrDefault(x => x.Id == pendencia.LocacaoFk).Status = "Aprovado!";

            db.Entry(pendencia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PendenciaExists(id))
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

        // POST: api/Pendencias
        [ResponseType(typeof(Pendencia))]
        public async Task<IHttpActionResult> PostPendencia(Pendencia pendencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pendencias.Add(pendencia);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pendencia.Id }, pendencia);
        }

        // DELETE: api/Pendencias/5
        [ResponseType(typeof(Pendencia))]
        public async Task<IHttpActionResult> DeletePendencia(int id)
        {
            Pendencia pendencia = await db.Pendencias.FindAsync(id);
            if (pendencia == null)
            {
                return NotFound();
            }

            db.Pendencias.Find(id).Ativo = false;
            await db.SaveChangesAsync();

            return Ok(pendencia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PendenciaExists(int id)
        {
            return db.Pendencias.Count(e => e.Id == id) > 0;
        }
    }
}