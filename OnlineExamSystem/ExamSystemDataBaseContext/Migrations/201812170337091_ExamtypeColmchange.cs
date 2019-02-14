namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExamtypeColmchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExamTypes", "ExamtypeName", c => c.String());
            AlterColumn("dbo.ExamTypes", "Examtype", c => c.Int(nullable: false));
            DropColumn("dbo.ExamTypes", "ExamtypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExamTypes", "ExamtypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.ExamTypes", "Examtype", c => c.String());
            DropColumn("dbo.ExamTypes", "ExamtypeName");
        }
    }
}
