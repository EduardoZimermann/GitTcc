using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TccLocacao.Models
{
    public class ContextDB : DbContext
    {
        public DbSet<TipoVeiculo> TipoVeiculos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Termo> Termos { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
    }
}