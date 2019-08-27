namespace TccGaragem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Termo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Termoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoTermo = c.Int(nullable: false),
                        Descricao = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Termoes");
        }
    }
}
