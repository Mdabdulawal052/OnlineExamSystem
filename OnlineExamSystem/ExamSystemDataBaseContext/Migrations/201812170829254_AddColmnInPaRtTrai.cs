namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColmnInPaRtTrai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.Trainers", "CourseId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "CourseId");
            DropColumn("dbo.Participants", "CourseId");
        }
    }
}
