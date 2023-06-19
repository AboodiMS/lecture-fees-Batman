namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LectureHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        NumberOfHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TheForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfessorId = c.Int(nullable: false),
                        ScientificRankCode = c.Int(nullable: false),
                        SubjectCode = c.Int(nullable: false),
                        FormDate = c.DateTimeOffset(nullable: false, precision: 7),
                        LectureHoursId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumberOfHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsPaied = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LectureHours", t => t.LectureHoursId)
                .ForeignKey("dbo.Professors", t => t.ProfessorId)
                .ForeignKey("dbo.ScientificRanks", t => t.ScientificRankCode)
                .ForeignKey("dbo.Subjects", t => t.SubjectCode)
                .Index(t => t.ProfessorId)
                .Index(t => t.ScientificRankCode)
                .Index(t => t.SubjectCode)
                .Index(t => t.LectureHoursId);
            
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
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Code);
            
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
            DropForeignKey("dbo.TheForms", "SubjectCode", "dbo.Subjects");
            DropForeignKey("dbo.TheForms", "ScientificRankCode", "dbo.ScientificRanks");
            DropForeignKey("dbo.TheForms", "ProfessorId", "dbo.Professors");
            DropForeignKey("dbo.Subjects", "ProfessorId", "dbo.Professors");
            DropForeignKey("dbo.Professors", "ScientificRankCode", "dbo.ScientificRanks");
            DropForeignKey("dbo.TheForms", "LectureHoursId", "dbo.LectureHours");
            DropIndex("dbo.Subjects", new[] { "ProfessorId" });
            DropIndex("dbo.Professors", new[] { "ScientificRankCode" });
            DropIndex("dbo.TheForms", new[] { "LectureHoursId" });
            DropIndex("dbo.TheForms", new[] { "SubjectCode" });
            DropIndex("dbo.TheForms", new[] { "ScientificRankCode" });
            DropIndex("dbo.TheForms", new[] { "ProfessorId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.ScientificRanks");
            DropTable("dbo.Professors");
            DropTable("dbo.TheForms");
            DropTable("dbo.LectureHours");
        }
    }
}
