namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPartiandTrainerAss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BatchParticipantAsses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchId = c.Int(nullable: false),
                        ParticipantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BatchTrainerAsses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchId = c.Int(nullable: false),
                        TrainerId = c.Int(nullable: false),
                        LeadTrainer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CourseAssings", "CourseId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseAssings", "CourseId");
            DropTable("dbo.BatchTrainerAsses");
            DropTable("dbo.BatchParticipantAsses");
        }
    }
}
