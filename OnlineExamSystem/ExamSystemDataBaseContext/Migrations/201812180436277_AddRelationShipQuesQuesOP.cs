namespace ExamSystemDataBaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationShipQuesQuesOP : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.QOptions", "QuestionId");
            AddForeignKey("dbo.QOptions", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QOptions", "QuestionId", "dbo.Questions");
            DropIndex("dbo.QOptions", new[] { "QuestionId" });
        }
    }
}
