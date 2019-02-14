namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableExamType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExamTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Examtype = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Exams", "ExamType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exams", "ExamType", c => c.String());
            DropTable("dbo.ExamTypes");
        }
    }
}
