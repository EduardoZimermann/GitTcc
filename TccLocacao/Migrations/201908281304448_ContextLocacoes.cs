namespace TccLocacao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextLocacoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Placa = c.String(),
                        AceiteTermo = c.Boolean(nullable: false),
                        Cor_Id = c.Int(),
                        Marca_Id = c.Int(),
                        Modelo_Id = c.Int(),
                        Periodo_Id = c.Int(),
                        TipoVeiculo_Id = c.Int(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cors", t => t.Cor_Id)
                .ForeignKey("dbo.Marcas", t => t.Marca_Id)
                .ForeignKey("dbo.Modeloes", t => t.Modelo_Id)
                .ForeignKey("dbo.Periodoes", t => t.Periodo_Id)
                .ForeignKey("dbo.TipoVeiculoes", t => t.TipoVeiculo_Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Cor_Id)
                .Index(t => t.Marca_Id)
                .Index(t => t.Modelo_Id)
                .Index(t => t.Periodo_Id)
                .Index(t => t.TipoVeiculo_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoUsuario = c.Int(nullable: false),
                        Nome = c.String(),
                        Email = c.String(),
                        ResideFora = c.Boolean(nullable: false),
                        OfereceCarona = c.Boolean(nullable: false),
                        PCD = c.Boolean(nullable: false),
                        TrabalhoNoturno = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacaos", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Locacaos", "TipoVeiculo_Id", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Locacaos", "Periodo_Id", "dbo.Periodoes");
            DropForeignKey("dbo.Locacaos", "Modelo_Id", "dbo.Modeloes");
            DropForeignKey("dbo.Locacaos", "Marca_Id", "dbo.Marcas");
            DropForeignKey("dbo.Locacaos", "Cor_Id", "dbo.Cors");
            DropIndex("dbo.Locacaos", new[] { "Usuario_Id" });
            DropIndex("dbo.Locacaos", new[] { "TipoVeiculo_Id" });
            DropIndex("dbo.Locacaos", new[] { "Periodo_Id" });
            DropIndex("dbo.Locacaos", new[] { "Modelo_Id" });
            DropIndex("dbo.Locacaos", new[] { "Marca_Id" });
            DropIndex("dbo.Locacaos", new[] { "Cor_Id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Locacaos");
        }
    }
}
