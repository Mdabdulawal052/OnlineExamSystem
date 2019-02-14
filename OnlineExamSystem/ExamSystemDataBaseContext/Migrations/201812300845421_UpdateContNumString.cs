namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContNumString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizations", "ContactNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "ContactNumber", c => c.Int(nullable: false));
        }
    }
}
