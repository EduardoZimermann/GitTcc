namespace Garagem.Migrations
{
    using Garagem.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garagem.Models.ContextDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garagem.Models.ContextDB context)
        {
            var TipoVeiculos = new List<TipoVeiculo>() {
                new TipoVeiculo(){CodigoTipo = 1,Descricao = "Automóvel"},
                new TipoVeiculo(){CodigoTipo = 2,Descricao = "Moto"},
                new TipoVeiculo(){CodigoTipo = 3,Descricao = "Bicicleta"},
                new TipoVeiculo(){CodigoTipo = 4,Descricao = "Patinete"},
                };

            TipoVeiculos.ForEach(s => context.TipoVeiculos.AddOrUpdate(p => p.Descricao, s));
            context.SaveChanges();
        }
    }
}
