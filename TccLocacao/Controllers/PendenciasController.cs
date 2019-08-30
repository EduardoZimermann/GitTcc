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

        [Route("api/Pendencias/{codigoPeriodo}/Sorteio")]
        [HttpPut]
        public List<string> RealizarSorteio(int codigoPeriodo)
        {
            List<string> retorno = new List<string>();
            Periodo periodo = db.Periodos.FirstOrDefault(x => x.CodigoPeriodo == codigoPeriodo);
            List<Pendencia> pendenciaList = new List<Pendencia>();
            foreach (var item in db.Pendencias)
            {
                if (db.Locacoes.Find(item.LocacaoFk).PeriodoFk == periodo.Id && db.Locacoes.Find(item.LocacaoFk).Status == "Em aprovação!")
                    pendenciaList.Add(item);
            }
            int countp = pendenciaList.Count();

            if (countp > periodo.Vagas && periodo.Vagas > 0)
            {
                retorno.Add("Lista de aprovados!");
                                                                                                                                                                                                                                                                                                                                                                        
                for (int i = 0; i < periodo.Vagas; i++)
                {
                    bool sorteado = false;

                    while (!sorteado)
                    {
                        int numeroSorteado = RandomNumber(0, countp);

                        if (!pendenciaList[numeroSorteado].Aprovado)
                        {
                            db.Pendencias.Find(pendenciaList[numeroSorteado].Id).Aprovado = true;
                            retorno.Add("Código da pendência: " + pendenciaList[numeroSorteado].Id);
                            db.SaveChanges();
                            sorteado = true;
                        }
                    }
                }
            }
            else
            {
                retorno.Add("Não foi possível realizar o sorteio!");
            }

            return retorno;
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
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


            /*Caso o usuário gestor aprove a locação, este if verifica se há vaga disponível para o período da locação, e então
            altera o status para "Aprovado!" e subtrai a quantidade de vagas do período. Caso não tenha vaga, a atributo Aprovado
            volta a ser false.*/
            if (pendencia.Aprovado && db.Periodos.Find(db.Locacoes.Find(pendencia.LocacaoFk).PeriodoFk).Vagas > 0)
            {
                db.Locacoes.Find(pendencia.LocacaoFk).Status = "Aprovado!";
                db.Periodos.Find(db.Locacoes.Find(pendencia.LocacaoFk).PeriodoFk).Vagas -= 1;
                db.SaveChanges();
            }
            else
                pendencia.Aprovado = false;

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