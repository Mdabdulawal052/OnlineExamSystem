namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnOrganizationId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "OrganizationId", c => c.Int(nullable: false));
            AddColumn("dbo.Trainers", "OrganizationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "OrganizationId");
            DropColumn("dbo.Participants", "OrganizationId");
        }
    }
}
