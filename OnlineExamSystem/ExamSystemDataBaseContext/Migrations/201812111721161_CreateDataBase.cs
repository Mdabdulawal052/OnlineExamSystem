namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchNo = c.Int(nullable: false),
                        Description = c.String(),
                        SDate = c.DateTime(nullable: false),
                        EDate = c.DateTime(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        CourseDuration = c.Int(nullable: false),
                        Credit = c.String(),
                        OutLine = c.String(),
                        Tags = c.String(),
                        Organizationid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.Organizationid, cascadeDelete: true)
                .Index(t => t.Organizationid);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Topic = c.String(),
                        FMarks = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.Int(nullable: false),
                        Address = c.String(),
                        ContactNumber = c.Int(nullable: false),
                        About = c.String(),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RegNo = c.String(),
                        ContactNo = c.String(),
                        Email = c.String(),
                        AddLine1 = c.String(),
                        AddLine2 = c.String(),
                        City = c.String(),
                        PostCode = c.Int(nullable: false),
                        Country = c.String(),
                        Profession = c.String(),
                        HAcademic = c.String(),
                        Img = c.String(),
                        BatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .Index(t => t.BatchId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactNo = c.String(),
                        Email = c.String(),
                        AddLine1 = c.String(),
                        AddLine2 = c.String(),
                        City = c.String(),
                        PostCode = c.Int(nullable: false),
                        Country = c.String(),
                        Img = c.String(),
                        BatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .Index(t => t.BatchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Participants", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Courses", "Organizationid", "dbo.Organizations");
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Batches", "CourseId", "dbo.Courses");
            DropIndex("dbo.Trainers", new[] { "BatchId" });
            DropIndex("dbo.Participants", new[] { "BatchId" });
            DropIndex("dbo.Exams", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "Organizationid" });
            DropIndex("dbo.Batches", new[] { "CourseId" });
            DropTable("dbo.Trainers");
            DropTable("dbo.Participants");
            DropTable("dbo.Organizations");
            DropTable("dbo.Exams");
            DropTable("dbo.Courses");
            DropTable("dbo.Batches");
        }
    }
}
