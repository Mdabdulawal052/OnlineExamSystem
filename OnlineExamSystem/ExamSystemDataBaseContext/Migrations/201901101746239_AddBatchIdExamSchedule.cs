namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBatchIdExamSchedule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExamSchedules", "BatchId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExamSchedules", "BatchId");
        }
    }
}
