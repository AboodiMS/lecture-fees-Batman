namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ScientificRankCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScientificRanks", t => t.ScientificRankCode)
                .Index(t => t.ScientificRankCode);
            
            CreateTable(
                "dbo.ScientificRanks",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.TheForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfessorId = c.Int(nullable: false),
                        ScientificRankCode = c.Int(nullable: false),
                        SubjectCode = c.Int(nullable: false),
                        FormDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professors", t => t.ProfessorId)
                .ForeignKey("dbo.ScientificRanks", t => t.ScientificRankCode)
                .ForeignKey("dbo.Subjects", t => t.SubjectCode)
                .Index(t => t.ProfessorId)
                .Index(t => t.ScientificRankCode)
                .Index(t => t.SubjectCode);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProfessorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Professors", t => t.ProfessorId)
                .Index(t => t.ProfessorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Professors", "ScientificRankCode", "dbo.ScientificRanks");
            DropForeignKey("dbo.TheForms", "SubjectCode", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "ProfessorId", "dbo.Professors");
            DropForeignKey("dbo.TheForms", "ScientificRankCode", "dbo.ScientificRanks");
            DropForeignKey("dbo.TheForms", "ProfessorId", "dbo.Professors");
            DropIndex("dbo.Subjects", new[] { "ProfessorId" });
            DropIndex("dbo.TheForms", new[] { "SubjectCode" });
            DropIndex("dbo.TheForms", new[] { "ScientificRankCode" });
            DropIndex("dbo.TheForms", new[] { "ProfessorId" });
            DropIndex("dbo.Professors", new[] { "ScientificRankCode" });
            DropTable("dbo.Subjects");
            DropTable("dbo.TheForms");
            DropTable("dbo.ScientificRanks");
            DropTable("dbo.Professors");
        }
    }
}
