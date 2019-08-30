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
    public class LocacoesController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/Locacoes
        public IQueryable<Locacao> GetLocacoes()
        {
            return db.Locacoes.Where(x => x.Ativo == true);
        }

        // GET: api/Locacoes/5
        [ResponseType(typeof(Locacao))]
        public async Task<IHttpActionResult> GetLocacao(int id)
        {
            Locacao locacao = await db.Locacoes.FindAsync(id);
            if (locacao == null)
            {
                return NotFound();
            }

            return Ok(locacao);
        }

        /// <summary>
        /// E28 - Retorna valores principais de várias tabelas.
        /// </summary>
        /// <param name="mes">Mês a ser pesquisado</param>
        /// <returns>Retorna os valores referente ao mês informado</returns>
        [Route("api/Locacoes/{mes}/data")]
        [HttpGet]
        public IQueryable GetData(int mes)
        {
            var item = from loc in db.Locacoes
                       where loc.DataAlteracao.Month == mes
                       join user in db.Usuarios on loc.UsuarioFk equals user.Id
                       join tipo in db.TipoVeiculos on loc.TipoVeiculoFk equals tipo.Id
                       join marca in db.Marcas on loc.MarcaFk equals marca.Id
                       join modelo in db.Modelos on loc.ModeloFk equals modelo.Id
                       join cor in db.Cores on loc.CorFk equals cor.Id
                       join val in db.Valores on tipo.ValorFk equals val.Id
                       select new
                       {
                           user.Nome,
                           user.Email,
                           Tipo = tipo.Descricao,
                           Marca = marca.Descricao,
                           Modelo = modelo.Descricao,
                           Cor = cor.Descricao,
                           loc.Placa,
                           loc.Status,
                           val.Preco
                       };

            return item;
        }

        // PUT: api/Locacoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLocacao(int id, Locacao locacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locacao.Id)
            {
                return BadRequest();
            }

            db.Entry(locacao).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocacaoExists(id))
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

        // POST: api/Locacoes
        [ResponseType(typeof(Locacao))]
        public async Task<IHttpActionResult> PostLocacao(Locacao locacao)
        {
            locacao.TipoVeiculoFk = db.TipoVeiculos.FirstOrDefault(x => x.CodigoTipo == locacao.TipoVeiculoFk).Id;

            locacao.MarcaFk = db.Marcas.FirstOrDefault(x => x.CodigoMarca == locacao.MarcaFk).Id;

            locacao.ModeloFk = db.Modelos.FirstOrDefault(x => x.CodigoModelo == locacao.ModeloFk).Id;

            locacao.CorFk = db.Cores.FirstOrDefault(x => x.CodigoCor == locacao.CorFk).Id;

            locacao.PeriodoFk = db.Periodos.FirstOrDefault(x => x.CodigoPeriodo == locacao.PeriodoFk).Id;

            locacao.UsuarioFk = db.Usuarios.FirstOrDefault(x => x.CodigoUsuario == locacao.UsuarioFk).Id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Locacoes.Add(locacao);

            if (db.Usuarios.Find(locacao.UsuarioFk).TrabalhoNoturno)
            {
                if (db.Periodos.Find(locacao.PeriodoFk).Vagas > 0)
                {
                    locacao.Status = "Aprovado";
                    db.Periodos.Find(locacao.PeriodoFk).Vagas -= 1;
                }
                else
                {
                    locacao.Status = "Em Aprovação!";
                    AdicionaPendencia(locacao.Id);
                }
            }
            else
            {
                locacao.Status = "Em Aprovação!";
                AdicionaPendencia(locacao.Id);
            }

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = locacao.Id }, locacao);
        }

        private void AdicionaPendencia(int id)
        {
            Pendencia pendencia = new Pendencia()
            {
                LocacaoFk = id,
            };

            db.Pendencias.Add(pendencia);
        }

        // DELETE: api/Locacoes/5
        [ResponseType(typeof(Locacao))]
        public async Task<IHttpActionResult> DeleteLocacao(int id)
        {
            Locacao locacao = await db.Locacoes.FindAsync(id);
            if (locacao == null)
            {
                return NotFound();
            }

            db.Locacoes.Find(id).Ativo = false;
            await db.SaveChangesAsync();

            return Ok(locacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocacaoExists(int id)
        {
            return db.Locacoes.Count(e => e.Id == id) > 0;
        }
    }
}