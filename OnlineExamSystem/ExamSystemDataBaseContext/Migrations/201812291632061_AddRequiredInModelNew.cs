namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredInModelNew : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Participants", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Participants", "Img", c => c.String(nullable: false));
            AlterColumn("dbo.Trainers", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Trainers", "Img", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainers", "Img", c => c.String());
            AlterColumn("dbo.Trainers", "Name", c => c.String());
            AlterColumn("dbo.Participants", "Img", c => c.String());
            AlterColumn("dbo.Participants", "Name", c => c.String());
        }
    }
}
