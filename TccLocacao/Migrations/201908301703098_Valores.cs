namespace TccLocacao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Valores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Valors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Preco = c.Double(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Valors");
        }
    }
}
