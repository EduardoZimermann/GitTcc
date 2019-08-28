namespace TccLocacao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Esqueci : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locacaos", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Locacaos", "UsuarioCriacao", c => c.Int(nullable: false));
            AddColumn("dbo.Locacaos", "UsuarioAlteracao", c => c.Int(nullable: false));
            AddColumn("dbo.Locacaos", "DataCriacao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Locacaos", "DataAlteracao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Usuarios", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "UsuarioCriacao", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "UsuarioAlteracao", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "DataCriacao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Usuarios", "DataAlteracao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "DataAlteracao");
            DropColumn("dbo.Usuarios", "DataCriacao");
            DropColumn("dbo.Usuarios", "UsuarioAlteracao");
            DropColumn("dbo.Usuarios", "UsuarioCriacao");
            DropColumn("dbo.Usuarios", "Ativo");
            DropColumn("dbo.Locacaos", "DataAlteracao");
            DropColumn("dbo.Locacaos", "DataCriacao");
            DropColumn("dbo.Locacaos", "UsuarioAlteracao");
            DropColumn("dbo.Locacaos", "UsuarioCriacao");
            DropColumn("dbo.Locacaos", "Ativo");
        }
    }
}
