namespace LocacaoDeGaragens.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Codigos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cors", "Codigo", c => c.Int(nullable: false));
            AddColumn("dbo.ModeloAutomovels", "Codigo", c => c.Int(nullable: false));
            AddColumn("dbo.ModeloMotoes", "Codigo", c => c.Int(nullable: false));
            AddColumn("dbo.PeriodoLocacaos", "Codigo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PeriodoLocacaos", "Codigo");
            DropColumn("dbo.ModeloMotoes", "Codigo");
            DropColumn("dbo.ModeloAutomovels", "Codigo");
            DropColumn("dbo.Cors", "Codigo");
        }
    }
}
