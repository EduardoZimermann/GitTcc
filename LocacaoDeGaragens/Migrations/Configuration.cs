namespace LocacaoDeGaragens.Migrations
{
    using LocacaoDeGaragens.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LocacaoDeGaragens.Models.ContextDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LocacaoDeGaragens.Models.ContextDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Veiculos.AddOrUpdate(x => x.Codigo,
                new Veiculo() { Codigo = 1, Tipo = "Automóvel" },
                new Veiculo() { Codigo = 2, Tipo = "Bicicleta" },
                new Veiculo() { Codigo = 3, Tipo = "Moto" },
                new Veiculo() { Codigo = 4, Tipo = "Patinete" }
            );

            context.MarcaAutomovels.AddOrUpdate(x => x.Codigo,
                new MarcaAutomovel() { Codigo = 1, Marca = "Audi" },
                new MarcaAutomovel() { Codigo = 2, Marca = "BMW" },
                new MarcaAutomovel() { Codigo = 3, Marca = "Chevrolet" },
                new MarcaAutomovel() { Codigo = 4, Marca = "Citröen" }
            );

            context.MarcaMotos.AddOrUpdate(x => x.Codigo,
                new MarcaMoto() { Codigo = 1, Marca = "Dafra" },
                new MarcaMoto() { Codigo = 2, Marca = "Honda" },
                new MarcaMoto() { Codigo = 3, Marca = "Suzuki" },
                new MarcaMoto() { Codigo = 4, Marca = "Yamaha" }
            );

            context.ModeloAutomovels.AddOrUpdate(x => x.Codigo,
                new ModeloAutomovel() { Codigo = 1, MarcaFk = 17, Modelo = "100" },
                new ModeloAutomovel() { Codigo = 2, MarcaFk = 18, Modelo = "1M" },
                new ModeloAutomovel() { Codigo = 3, MarcaFk = 19, Modelo = "A10" },
                new ModeloAutomovel() { Codigo = 4, MarcaFk = 20, Modelo = "Aircross" }
            );

            context.ModeloMotos.AddOrUpdate(x => x.Codigo,
                new ModeloMoto() { Codigo = 1, MarcaFk = 24, Modelo = "Apache" },
                new ModeloMoto() { Codigo = 2, MarcaFk = 25, Modelo = "America Classic" },
                new ModeloMoto() { Codigo = 3, MarcaFk = 26, Modelo = "Address Ae" },
                new ModeloMoto() { Codigo = 4, MarcaFk = 26, Modelo = "Axis 90" }
            );

            context.Cors.AddOrUpdate(x => x.Codigo,
                new Cor() { Codigo = 1, Nome = "Branco" },
                new Cor() { Codigo = 2, Nome = "Preto" },
                new Cor() { Codigo = 3, Nome = "Prata" },
                new Cor() { Codigo = 4, Nome = "Cinza" },
                new Cor() { Codigo = 5, Nome = "Vermelho" },
                new Cor() { Codigo = 6, Nome = "Marrom/Bege" },
                new Cor() { Codigo = 7, Nome = "Azul" },
                new Cor() { Codigo = 8, Nome = "Verde" },
                new Cor() { Codigo = 9, Nome = "Amarelo/Dourado" },
                new Cor() { Codigo = 10, Nome = "Outras" }
            );
        }
    }
}
