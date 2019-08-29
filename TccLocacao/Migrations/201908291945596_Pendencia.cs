namespace TccLocacao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pendencia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pendencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocacaoFk = c.Int(nullable: false),
                        Aprovado = c.Boolean(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locacaos", t => t.LocacaoFk, cascadeDelete: true)
                .Index(t => t.LocacaoFk);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pendencias", "LocacaoFk", "dbo.Locacaos");
            DropIndex("dbo.Pendencias", new[] { "LocacaoFk" });
            DropTable("dbo.Pendencias");
        }
    }
}
