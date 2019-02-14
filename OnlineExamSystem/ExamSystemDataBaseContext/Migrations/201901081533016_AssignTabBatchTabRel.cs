namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignTabBatchTabRel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BatchParticipantAsses", "ParticipantId");
            CreateIndex("dbo.BatchTrainerAsses", "TrainerId");
            AddForeignKey("dbo.BatchParticipantAsses", "ParticipantId", "dbo.Participants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BatchTrainerAsses", "TrainerId", "dbo.Trainers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BatchTrainerAsses", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.BatchParticipantAsses", "ParticipantId", "dbo.Participants");
            DropIndex("dbo.BatchTrainerAsses", new[] { "TrainerId" });
            DropIndex("dbo.BatchParticipantAsses", new[] { "ParticipantId" });
        }
    }
}
