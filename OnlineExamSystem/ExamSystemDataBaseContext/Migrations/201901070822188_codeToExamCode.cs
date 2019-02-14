namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class codeToExamCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "ExamCode", c => c.Int(nullable: false));
            DropColumn("dbo.Exams", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exams", "Code", c => c.Int(nullable: false));
            DropColumn("dbo.Exams", "ExamCode");
        }
    }
}
