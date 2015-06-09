using System.Collections.Generic;
using System.Linq;
using TrainingsCalendar.Domain.Abstract;
using TrainingsCalendar.Domain.Entities;

namespace TrainingsCalendar.Domain.Concrete
{
    public class TrainingsRepository : ITrainingsRepository
    {
        readonly EFDbContext _context = new EFDbContext();

        public ICollection<Event> Events
        {
            get { return _context.Events.ToList(); }
        }

        public ICollection<Trainer> Trainers
        {
            get { return _context.Trainers.ToList(); }
        }

        public ICollection<Trainers_Training> TrainersTrainings
        {
            get { return _context.TrainersTrainings.ToList(); }
        }

        public ICollection<Training> Trainings
        {
            get { return _context.Trainings.ToList(); }
        }
    }
}
