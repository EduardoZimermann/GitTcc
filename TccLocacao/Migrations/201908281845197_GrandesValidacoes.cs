namespace TccLocacao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GrandesValidacoes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacaos", "Periodo_Id", "dbo.Periodoes");
            DropForeignKey("dbo.Locacaos", "TipoVeiculo_Id", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Locacaos", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.Locacaos", new[] { "Periodo_Id" });
            DropIndex("dbo.Locacaos", new[] { "TipoVeiculo_Id" });
            DropIndex("dbo.Locacaos", new[] { "Usuario_Id" });
            AlterColumn("dbo.Locacaos", "Periodo_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "TipoVeiculo_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "Usuario_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Locacaos", "Periodo_Id");
            CreateIndex("dbo.Locacaos", "TipoVeiculo_Id");
            CreateIndex("dbo.Locacaos", "Usuario_Id");
            AddForeignKey("dbo.Locacaos", "Periodo_Id", "dbo.Periodoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "TipoVeiculo_Id", "dbo.TipoVeiculoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "Usuario_Id", "dbo.Usuarios", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacaos", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Locacaos", "TipoVeiculo_Id", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Locacaos", "Periodo_Id", "dbo.Periodoes");
            DropIndex("dbo.Locacaos", new[] { "Usuario_Id" });
            DropIndex("dbo.Locacaos", new[] { "TipoVeiculo_Id" });
            DropIndex("dbo.Locacaos", new[] { "Periodo_Id" });
            AlterColumn("dbo.Locacaos", "Usuario_Id", c => c.Int());
            AlterColumn("dbo.Locacaos", "TipoVeiculo_Id", c => c.Int());
            AlterColumn("dbo.Locacaos", "Periodo_Id", c => c.Int());
            CreateIndex("dbo.Locacaos", "Usuario_Id");
            CreateIndex("dbo.Locacaos", "TipoVeiculo_Id");
            CreateIndex("dbo.Locacaos", "Periodo_Id");
            AddForeignKey("dbo.Locacaos", "Usuario_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.Locacaos", "TipoVeiculo_Id", "dbo.TipoVeiculoes", "Id");
            AddForeignKey("dbo.Locacaos", "Periodo_Id", "dbo.Periodoes", "Id");
        }
    }
}
