namespace TccLocacao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValorChave : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipoVeiculoes", "ValorFk", c => c.Int(nullable: false));
            CreateIndex("dbo.TipoVeiculoes", "ValorFk");
            AddForeignKey("dbo.TipoVeiculoes", "ValorFk", "dbo.Valors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TipoVeiculoes", "ValorFk", "dbo.Valors");
            DropIndex("dbo.TipoVeiculoes", new[] { "ValorFk" });
            DropColumn("dbo.TipoVeiculoes", "ValorFk");
        }
    }
}
