using System.Collections.Generic;
using TrainingsCalendar.Domain.Entities;

namespace TrainingsCalendar.Domain.Abstract
{
    public interface ITrainingsRepository
    {
        ICollection<Event> Events { get; }
        ICollection<Trainer> Trainers { get; }
        ICollection<Trainers_Training> TrainersTrainings { get; }
        ICollection<Training> Trainings { get; } 
    }
}
