namespace TccGaragem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoCor = c.Int(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoMarca = c.Int(nullable: false),
                        Descricao = c.String(),
                        TipoVeiculo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoVeiculoes", t => t.TipoVeiculo_Id)
                .Index(t => t.TipoVeiculo_Id);
            
            CreateTable(
                "dbo.TipoVeiculoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoTipo = c.Int(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoModelo = c.Int(nullable: false),
                        Descricao = c.String(),
                        Marca_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marcas", t => t.Marca_Id)
                .Index(t => t.Marca_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modeloes", "Marca_Id", "dbo.Marcas");
            DropForeignKey("dbo.Marcas", "TipoVeiculo_Id", "dbo.TipoVeiculoes");
            DropIndex("dbo.Modeloes", new[] { "Marca_Id" });
            DropIndex("dbo.Marcas", new[] { "TipoVeiculo_Id" });
            DropTable("dbo.Modeloes");
            DropTable("dbo.TipoVeiculoes");
            DropTable("dbo.Marcas");
            DropTable("dbo.Cors");
        }
    }
}
