namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecourseListTrainer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseAssings", "TrainerId", "dbo.Trainers");
            DropIndex("dbo.CourseAssings", new[] { "TrainerId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.CourseAssings", "TrainerId");
            AddForeignKey("dbo.CourseAssings", "TrainerId", "dbo.Trainers", "Id", cascadeDelete: true);
        }
    }
}
