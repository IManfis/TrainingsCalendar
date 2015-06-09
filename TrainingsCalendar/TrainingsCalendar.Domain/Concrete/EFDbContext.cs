using System.Data.Entity;
using TrainingsCalendar.Domain.Entities;

namespace TrainingsCalendar.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Trainers_Training> TrainersTrainings { get; set; }
        public DbSet<Training> Trainings { get; set; } 
    }
}
