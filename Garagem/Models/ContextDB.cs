using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garagem.Models
{
    public class ContextDB : DbContext
    {
        public DbSet<TipoVeiculo> TipoVeiculos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Cor> Cors { get; set; }
    }
}