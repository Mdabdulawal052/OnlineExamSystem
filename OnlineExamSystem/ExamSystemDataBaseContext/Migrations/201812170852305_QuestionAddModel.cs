namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionAddModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Option = c.String(),
                        checkbox = c.Boolean(nullable: false),
                        Sl = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WriteQuestion = c.String(),
                        Marks = c.Double(nullable: false),
                        QuestionOrder = c.Int(nullable: false),
                        ExamId = c.Int(nullable: false),
                        OptionTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionTypes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Questions");
            DropTable("dbo.QOptions");
        }
    }
}
