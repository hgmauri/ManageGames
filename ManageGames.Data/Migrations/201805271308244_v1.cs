using System.Data.Entity.Migrations;

namespace ManageGames.Data.Migrations
{
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Amigo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 160),
                        Apelido = c.String(),
                        Idade = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emprestimo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Amigo_Id = c.Guid(),
                        Jogo_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Amigo", t => t.Amigo_Id)
                .ForeignKey("dbo.Jogo", t => t.Jogo_Id)
                .Index(t => t.Amigo_Id)
                .Index(t => t.Jogo_Id);
            
            CreateTable(
                "dbo.Jogo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Genero_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genero", t => t.Genero_Id, cascadeDelete: true)
                .Index(t => t.Genero_Id);
            
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emprestimo", "Jogo_Id", "dbo.Jogo");
            DropForeignKey("dbo.Jogo", "Genero_Id", "dbo.Genero");
            DropForeignKey("dbo.Emprestimo", "Amigo_Id", "dbo.Amigo");
            DropIndex("dbo.Jogo", new[] { "Genero_Id" });
            DropIndex("dbo.Emprestimo", new[] { "Jogo_Id" });
            DropIndex("dbo.Emprestimo", new[] { "Amigo_Id" });
            DropTable("dbo.Genero");
            DropTable("dbo.Jogo");
            DropTable("dbo.Emprestimo");
            DropTable("dbo.Amigo");
        }
    }
}
