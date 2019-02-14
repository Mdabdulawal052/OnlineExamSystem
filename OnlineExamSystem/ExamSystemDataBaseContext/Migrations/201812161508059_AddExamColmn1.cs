namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExamColmn1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "ExamType", c => c.String());
            AddColumn("dbo.Exams", "Duration", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exams", "Duration");
            DropColumn("dbo.Exams", "ExamType");
        }
    }
}
