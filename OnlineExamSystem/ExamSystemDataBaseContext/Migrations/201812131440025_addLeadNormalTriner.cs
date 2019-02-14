namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLeadNormalTriner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseAssings", "LeadTrainer", c => c.Boolean());
            AddColumn("dbo.CourseAssings", "NormalTrainer", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseAssings", "NormalTrainer");
            DropColumn("dbo.CourseAssings", "LeadTrainer");
        }
    }
}
