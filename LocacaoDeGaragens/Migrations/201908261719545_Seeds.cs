namespace LocacaoDeGaragens.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seeds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PeriodoLocacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoFk = c.Int(nullable: false),
                        DataInicial = c.DateTime(nullable: false),
                        DataFinal = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Veiculoes", t => t.TipoFk, cascadeDelete: true)
                .Index(t => t.TipoFk);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeriodoLocacaos", "TipoFk", "dbo.Veiculoes");
            DropIndex("dbo.PeriodoLocacaos", new[] { "TipoFk" });
            DropTable("dbo.PeriodoLocacaos");
        }
    }
}
