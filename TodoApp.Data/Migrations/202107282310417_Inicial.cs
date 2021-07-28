namespace TodoApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Todo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UsuarioId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        Vencimento = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Criacao = c.DateTime(),
                        Alteracao = c.DateTime(),
                        UsuarioCriacao = c.Guid(),
                        UsuarioAlteracao = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        Sobrenome = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Criacao = c.DateTime(),
                        Alteracao = c.DateTime(),
                        UsuarioCriacao = c.Guid(),
                        UsuarioAlteracao = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todo", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Todo", new[] { "UsuarioId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Todo");
        }
    }
}
