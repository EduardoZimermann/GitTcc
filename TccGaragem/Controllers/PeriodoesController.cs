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
    public class PeriodoesController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/Periodoes
        public List<string> GetPeriodos()
        {
            var listaDePeriodos = new List<string>();

            foreach (var item in db.Periodos)
            {
                listaDePeriodos.Add($"Tipo: {item.TipoVeiculo.CodigoTipo}, CódigoPeríodo: {item.CodigoPeriodo}, " +
                    $"de {item.DataInicial.ToString("dd/MM/yyyy")} até {item.DataFinal.ToString("dd/MM/yyyy")}");
            }

            return listaDePeriodos;
        }

        // GET: api/Periodoes/5
        [ResponseType(typeof(Periodo))]
        public IQueryable<Periodo> GetPeriodo(int id)
        {
            return db.Periodos.Where(x => x.TipoVeiculo.CodigoTipo == id && x.DataFinal > DateTime.Now);
        }

        /*[ResponseType(typeof(Periodo))]
        public async Task<IHttpActionResult> GetPeriodo(int id)
        {
            Periodo periodo = await db.Periodos.FindAsync(id);
            if (periodo == null)
            {
                return NotFound();
            }

            return Ok(periodo);
        }*/

        // PUT: api/Periodoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPeriodo(int id, Periodo periodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != periodo.Id)
            {
                return BadRequest();
            }

            db.Entry(periodo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeriodoExists(id))
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

        // POST: api/Periodoes
        [ResponseType(typeof(Periodo))]
        public async Task<IHttpActionResult> PostPeriodo(Periodo periodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Periodos.Add(periodo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = periodo.Id }, periodo);
        }

        // DELETE: api/Periodoes/5
        [ResponseType(typeof(Periodo))]
        public async Task<IHttpActionResult> DeletePeriodo(int id)
        {
            Periodo periodo = await db.Periodos.FindAsync(id);
            if (periodo == null)
            {
                return NotFound();
            }

            db.Periodos.Remove(periodo);
            await db.SaveChangesAsync();

            return Ok(periodo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeriodoExists(int id)
        {
            return db.Periodos.Count(e => e.Id == id) > 0;
        }
    }
}