namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationTrinerAssTriner : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CourseAssings", "TrainerId");
            AddForeignKey("dbo.CourseAssings", "TrainerId", "dbo.Trainers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseAssings", "TrainerId", "dbo.Trainers");
            DropIndex("dbo.CourseAssings", new[] { "TrainerId" });
        }
    }
}
