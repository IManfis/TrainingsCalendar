namespace TrainingsCalendar.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainings", "Partition", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainings", "Partition");
        }
    }
}
