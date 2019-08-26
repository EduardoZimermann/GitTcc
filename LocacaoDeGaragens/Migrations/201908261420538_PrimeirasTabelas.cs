namespace LocacaoDeGaragens.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeirasTabelas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MarcaAutomovels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marca = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MarcaMotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marca = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModeloAutomovels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marca = c.Int(nullable: false),
                        Modelo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModeloMotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marca = c.Int(nullable: false),
                        Modelo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Veiculoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Veiculoes");
            DropTable("dbo.ModeloMotoes");
            DropTable("dbo.ModeloAutomovels");
            DropTable("dbo.MarcaMotoes");
            DropTable("dbo.MarcaAutomovels");
            DropTable("dbo.Cors");
        }
    }
}
