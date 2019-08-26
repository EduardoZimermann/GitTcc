namespace LocacaoDeGaragens.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChaveEstrangeira : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ModeloAutomovels", "MarcaFk", c => c.Int(nullable: false));
            AddColumn("dbo.ModeloMotoes", "MarcaFk", c => c.Int(nullable: false));
            CreateIndex("dbo.ModeloAutomovels", "MarcaFk");
            CreateIndex("dbo.ModeloMotoes", "MarcaFk");
            AddForeignKey("dbo.ModeloAutomovels", "MarcaFk", "dbo.MarcaAutomovels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ModeloMotoes", "MarcaFk", "dbo.MarcaMotoes", "Id", cascadeDelete: true);
            DropColumn("dbo.ModeloAutomovels", "Marca");
            DropColumn("dbo.ModeloMotoes", "Marca");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ModeloMotoes", "Marca", c => c.Int(nullable: false));
            AddColumn("dbo.ModeloAutomovels", "Marca", c => c.Int(nullable: false));
            DropForeignKey("dbo.ModeloMotoes", "MarcaFk", "dbo.MarcaMotoes");
            DropForeignKey("dbo.ModeloAutomovels", "MarcaFk", "dbo.MarcaAutomovels");
            DropIndex("dbo.ModeloMotoes", new[] { "MarcaFk" });
            DropIndex("dbo.ModeloAutomovels", new[] { "MarcaFk" });
            DropColumn("dbo.ModeloMotoes", "MarcaFk");
            DropColumn("dbo.ModeloAutomovels", "MarcaFk");
        }
    }
}
