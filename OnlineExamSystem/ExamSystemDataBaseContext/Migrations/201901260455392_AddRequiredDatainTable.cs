namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredDatainTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AdminLogIns", "name", c => c.String(nullable: false));
            AlterColumn("dbo.AdminLogIns", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.AdminLogIns", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.UserLogins", "name", c => c.String(nullable: false));
            AlterColumn("dbo.UserLogins", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.UserLogins", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserLogins", "Email", c => c.String());
            AlterColumn("dbo.UserLogins", "Password", c => c.String());
            AlterColumn("dbo.UserLogins", "name", c => c.String());
            AlterColumn("dbo.AdminLogIns", "Email", c => c.String());
            AlterColumn("dbo.AdminLogIns", "Password", c => c.String());
            AlterColumn("dbo.AdminLogIns", "name", c => c.String());
        }
    }
}
