namespace TrainingsCalendar.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainings", "ColorPast", c => c.String());
            AddColumn("dbo.Trainings", "ColorFuture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainings", "ColorFuture");
            DropColumn("dbo.Trainings", "ColorPast");
        }
    }
}
