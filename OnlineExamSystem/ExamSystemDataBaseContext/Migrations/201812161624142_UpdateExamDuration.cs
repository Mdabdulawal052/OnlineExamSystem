namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateExamDuration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exams", "Duration", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exams", "Duration", c => c.String());
        }
    }
}
