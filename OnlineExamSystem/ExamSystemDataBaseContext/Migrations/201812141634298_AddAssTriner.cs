namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssTriner : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseAssings", "TrainerId", "dbo.Trainers");
            DropIndex("dbo.CourseAssings", new[] { "TrainerId" });
            AlterColumn("dbo.CourseAssings", "TrainerId", c => c.Int(nullable: false));
            CreateIndex("dbo.CourseAssings", "TrainerId");
            AddForeignKey("dbo.CourseAssings", "TrainerId", "dbo.Trainers", "Id", cascadeDelete: true);
            DropColumn("dbo.CourseAssings", "CourseId");
            DropColumn("dbo.CourseAssings", "ParticipantId");
            DropColumn("dbo.CourseAssings", "NormalTrainer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseAssings", "NormalTrainer", c => c.Boolean(nullable: false));
            AddColumn("dbo.CourseAssings", "ParticipantId", c => c.Int());
            AddColumn("dbo.CourseAssings", "CourseId", c => c.Int());
            DropForeignKey("dbo.CourseAssings", "TrainerId", "dbo.Trainers");
            DropIndex("dbo.CourseAssings", new[] { "TrainerId" });
            AlterColumn("dbo.CourseAssings", "TrainerId", c => c.Int());
            CreateIndex("dbo.CourseAssings", "TrainerId");
            AddForeignKey("dbo.CourseAssings", "TrainerId", "dbo.Trainers", "Id");
        }
    }
}
