namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationshipAssTandTrainer : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CourseAssings", "TrainerId");
            AddForeignKey("dbo.CourseAssings", "TrainerId", "dbo.Trainers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseAssings", "TrainerId", "dbo.Trainers");
            DropIndex("dbo.CourseAssings", new[] { "TrainerId" });
        }
    }
}
