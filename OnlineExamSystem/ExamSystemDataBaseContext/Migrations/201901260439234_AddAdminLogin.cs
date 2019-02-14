namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminLogin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        MobileNo = c.String(),
                        Address = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        MobileNo = c.String(),
                        Address = c.String(),
                        userData = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserLogins");
            DropTable("dbo.AdminLogIns");
        }
    }
}
