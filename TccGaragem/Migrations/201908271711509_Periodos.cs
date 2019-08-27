namespace TccGaragem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Periodos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Periodoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoPeriodo = c.Int(nullable: false),
                        DataInicial = c.DateTime(nullable: false),
                        DataFinal = c.DateTime(nullable: false),
                        TipoVeiculo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoVeiculoes", t => t.TipoVeiculo_Id)
                .Index(t => t.TipoVeiculo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Periodoes", "TipoVeiculo_Id", "dbo.TipoVeiculoes");
            DropIndex("dbo.Periodoes", new[] { "TipoVeiculo_Id" });
            DropTable("dbo.Periodoes");
        }
    }
}
