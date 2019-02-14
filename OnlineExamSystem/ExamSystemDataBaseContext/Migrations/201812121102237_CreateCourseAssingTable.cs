namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCourseAssingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseAssings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(),
                        TrainerId = c.Int(),
                        ParticipantId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CourseAssings");
        }
    }
}
