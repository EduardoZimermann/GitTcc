namespace TccLocacao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Chaves : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacaos", "Cor_Id", "dbo.Cors");
            DropForeignKey("dbo.Locacaos", "Marca_Id", "dbo.Marcas");
            DropForeignKey("dbo.Locacaos", "Modelo_Id", "dbo.Modeloes");
            DropForeignKey("dbo.Marcas", "TipoVeiculo_Id", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Modeloes", "Marca_Id", "dbo.Marcas");
            DropForeignKey("dbo.Periodoes", "TipoVeiculo_Id", "dbo.TipoVeiculoes");
            DropIndex("dbo.Locacaos", new[] { "Cor_Id" });
            DropIndex("dbo.Locacaos", new[] { "Marca_Id" });
            DropIndex("dbo.Locacaos", new[] { "Modelo_Id" });
            DropIndex("dbo.Marcas", new[] { "TipoVeiculo_Id" });
            DropIndex("dbo.Modeloes", new[] { "Marca_Id" });
            DropIndex("dbo.Periodoes", new[] { "TipoVeiculo_Id" });
            RenameColumn(table: "dbo.Locacaos", name: "Cor_Id", newName: "CorFk");
            RenameColumn(table: "dbo.Locacaos", name: "Marca_Id", newName: "MarcaFk");
            RenameColumn(table: "dbo.Locacaos", name: "Modelo_Id", newName: "ModeloFk");
            RenameColumn(table: "dbo.Locacaos", name: "Periodo_Id", newName: "PeriodoFk");
            RenameColumn(table: "dbo.Locacaos", name: "TipoVeiculo_Id", newName: "TipoVeiculoFk");
            RenameColumn(table: "dbo.Locacaos", name: "Usuario_Id", newName: "UsuarioFk");
            RenameColumn(table: "dbo.Marcas", name: "TipoVeiculo_Id", newName: "TipoVeiculoFk");
            RenameColumn(table: "dbo.Modeloes", name: "Marca_Id", newName: "MarcaFk");
            RenameColumn(table: "dbo.Periodoes", name: "TipoVeiculo_Id", newName: "TipoVeiculoFk");
            RenameIndex(table: "dbo.Locacaos", name: "IX_TipoVeiculo_Id", newName: "IX_TipoVeiculoFk");
            RenameIndex(table: "dbo.Locacaos", name: "IX_Periodo_Id", newName: "IX_PeriodoFk");
            RenameIndex(table: "dbo.Locacaos", name: "IX_Usuario_Id", newName: "IX_UsuarioFk");
            AlterColumn("dbo.Locacaos", "CorFk", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "MarcaFk", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "ModeloFk", c => c.Int(nullable: false));
            AlterColumn("dbo.Marcas", "TipoVeiculoFk", c => c.Int(nullable: false));
            AlterColumn("dbo.Modeloes", "MarcaFk", c => c.Int(nullable: false));
            AlterColumn("dbo.Periodoes", "TipoVeiculoFk", c => c.Int(nullable: false));
            CreateIndex("dbo.Locacaos", "MarcaFk");
            CreateIndex("dbo.Locacaos", "ModeloFk");
            CreateIndex("dbo.Locacaos", "CorFk");
            CreateIndex("dbo.Marcas", "TipoVeiculoFk");
            CreateIndex("dbo.Modeloes", "MarcaFk");
            CreateIndex("dbo.Periodoes", "TipoVeiculoFk");
            AddForeignKey("dbo.Locacaos", "CorFk", "dbo.Cors", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Locacaos", "MarcaFk", "dbo.Marcas", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Locacaos", "ModeloFk", "dbo.Modeloes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Marcas", "TipoVeiculoFk", "dbo.TipoVeiculoes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Modeloes", "MarcaFk", "dbo.Marcas", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Periodoes", "TipoVeiculoFk", "dbo.TipoVeiculoes", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Periodoes", "TipoVeiculoFk", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Modeloes", "MarcaFk", "dbo.Marcas");
            DropForeignKey("dbo.Marcas", "TipoVeiculoFk", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Locacaos", "ModeloFk", "dbo.Modeloes");
            DropForeignKey("dbo.Locacaos", "MarcaFk", "dbo.Marcas");
            DropForeignKey("dbo.Locacaos", "CorFk", "dbo.Cors");
            DropIndex("dbo.Periodoes", new[] { "TipoVeiculoFk" });
            DropIndex("dbo.Modeloes", new[] { "MarcaFk" });
            DropIndex("dbo.Marcas", new[] { "TipoVeiculoFk" });
            DropIndex("dbo.Locacaos", new[] { "CorFk" });
            DropIndex("dbo.Locacaos", new[] { "ModeloFk" });
            DropIndex("dbo.Locacaos", new[] { "MarcaFk" });
            AlterColumn("dbo.Periodoes", "TipoVeiculoFk", c => c.Int());
            AlterColumn("dbo.Modeloes", "MarcaFk", c => c.Int());
            AlterColumn("dbo.Marcas", "TipoVeiculoFk", c => c.Int());
            AlterColumn("dbo.Locacaos", "ModeloFk", c => c.Int());
            AlterColumn("dbo.Locacaos", "MarcaFk", c => c.Int());
            AlterColumn("dbo.Locacaos", "CorFk", c => c.Int());
            RenameIndex(table: "dbo.Locacaos", name: "IX_UsuarioFk", newName: "IX_Usuario_Id");
            RenameIndex(table: "dbo.Locacaos", name: "IX_PeriodoFk", newName: "IX_Periodo_Id");
            RenameIndex(table: "dbo.Locacaos", name: "IX_TipoVeiculoFk", newName: "IX_TipoVeiculo_Id");
            RenameColumn(table: "dbo.Periodoes", name: "TipoVeiculoFk", newName: "TipoVeiculo_Id");
            RenameColumn(table: "dbo.Modeloes", name: "MarcaFk", newName: "Marca_Id");
            RenameColumn(table: "dbo.Marcas", name: "TipoVeiculoFk", newName: "TipoVeiculo_Id");
            RenameColumn(table: "dbo.Locacaos", name: "UsuarioFk", newName: "Usuario_Id");
            RenameColumn(table: "dbo.Locacaos", name: "TipoVeiculoFk", newName: "TipoVeiculo_Id");
            RenameColumn(table: "dbo.Locacaos", name: "PeriodoFk", newName: "Periodo_Id");
            RenameColumn(table: "dbo.Locacaos", name: "ModeloFk", newName: "Modelo_Id");
            RenameColumn(table: "dbo.Locacaos", name: "MarcaFk", newName: "Marca_Id");
            RenameColumn(table: "dbo.Locacaos", name: "CorFk", newName: "Cor_Id");
            CreateIndex("dbo.Periodoes", "TipoVeiculo_Id");
            CreateIndex("dbo.Modeloes", "Marca_Id");
            CreateIndex("dbo.Marcas", "TipoVeiculo_Id");
            CreateIndex("dbo.Locacaos", "Modelo_Id");
            CreateIndex("dbo.Locacaos", "Marca_Id");
            CreateIndex("dbo.Locacaos", "Cor_Id");
            AddForeignKey("dbo.Periodoes", "TipoVeiculo_Id", "dbo.TipoVeiculoes", "Id");
            AddForeignKey("dbo.Modeloes", "Marca_Id", "dbo.Marcas", "Id");
            AddForeignKey("dbo.Marcas", "TipoVeiculo_Id", "dbo.TipoVeiculoes", "Id");
            AddForeignKey("dbo.Locacaos", "Modelo_Id", "dbo.Modeloes", "Id");
            AddForeignKey("dbo.Locacaos", "Marca_Id", "dbo.Marcas", "Id");
            AddForeignKey("dbo.Locacaos", "Cor_Id", "dbo.Cors", "Id");
        }
    }
}
