namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableExamTypeId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExamTypes", "ExamtypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExamTypes", "ExamtypeId");
        }
    }
}
