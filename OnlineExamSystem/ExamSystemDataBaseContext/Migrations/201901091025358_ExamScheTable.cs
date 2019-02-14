namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExamScheTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExamSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduleDateTime = c.DateTime(nullable: false),
                        ExamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .Index(t => t.ExamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamSchedules", "ExamId", "dbo.Exams");
            DropIndex("dbo.ExamSchedules", new[] { "ExamId" });
            DropTable("dbo.ExamSchedules");
        }
    }
}
