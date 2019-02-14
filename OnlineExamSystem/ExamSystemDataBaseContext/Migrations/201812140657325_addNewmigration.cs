namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "Lead", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CourseAssings", "LeadTrainer", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CourseAssings", "NormalTrainer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CourseAssings", "NormalTrainer", c => c.Boolean());
            AlterColumn("dbo.CourseAssings", "LeadTrainer", c => c.Boolean());
            DropColumn("dbo.Trainers", "Lead");
        }
    }
}
