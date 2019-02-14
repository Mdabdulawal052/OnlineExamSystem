namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredInModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String());
        }
    }
}
