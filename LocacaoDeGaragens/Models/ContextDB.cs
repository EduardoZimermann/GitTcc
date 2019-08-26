using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LocacaoDeGaragens.Models
{
    public class ContextDB : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<MarcaAutomovel> MarcaAutomovels { get; set; }
        public DbSet<MarcaMoto> MarcaMotos { get; set; }
        public DbSet<ModeloAutomovel> ModeloAutomovels { get; set; }
        public DbSet<ModeloMoto> ModeloMotos { get; set; }

        public System.Data.Entity.DbSet<LocacaoDeGaragens.Models.Cor> Cors { get; set; }

        public System.Data.Entity.DbSet<LocacaoDeGaragens.Models.PeriodoLocacao> PeriodoLocacaos { get; set; }
    }
}