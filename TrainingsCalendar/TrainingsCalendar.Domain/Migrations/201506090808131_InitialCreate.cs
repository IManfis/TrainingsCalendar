namespace TrainingsCalendar.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TrainingID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Trainings", t => t.TrainingID, cascadeDelete: true)
                .Index(t => t.TrainingID);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TrainingName = c.String(),
                        About = c.String(),
                        TrainingType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trainers_Training",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TrainingID = c.Int(nullable: false),
                        TrainersID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Trainers", t => t.TrainersID, cascadeDelete: true)
                .ForeignKey("dbo.Trainings", t => t.TrainingID, cascadeDelete: true)
                .Index(t => t.TrainingID)
                .Index(t => t.TrainersID);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers_Training", "TrainingID", "dbo.Trainings");
            DropForeignKey("dbo.Trainers_Training", "TrainersID", "dbo.Trainers");
            DropForeignKey("dbo.Events", "TrainingID", "dbo.Trainings");
            DropIndex("dbo.Trainers_Training", new[] { "TrainersID" });
            DropIndex("dbo.Trainers_Training", new[] { "TrainingID" });
            DropIndex("dbo.Events", new[] { "TrainingID" });
            DropTable("dbo.Trainers");
            DropTable("dbo.Trainers_Training");
            DropTable("dbo.Trainings");
            DropTable("dbo.Events");
        }
    }
}
