namespace TccLocacao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sorteio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Periodoes", "Vagas", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Periodoes", "Vagas");
        }
    }
}
