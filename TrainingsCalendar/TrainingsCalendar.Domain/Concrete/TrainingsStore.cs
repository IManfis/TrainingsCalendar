using System.Collections.Generic;
using System.Linq;
using TrainingsCalendar.Domain.Abstract;
using TrainingsCalendar.Domain.Entities;

namespace TrainingsCalendar.Domain.Concrete
{
    public class TrainingsStore : ITrainingsStore
    {
        private readonly ITrainingsRepository _repository;
        readonly EFDbContext _context = new EFDbContext();

        public TrainingsStore(ITrainingsRepository repository)
        {
            _repository = repository;
        }

        public List<Event> GetAllEvents()
        {
            return _repository.Events.ToList();
        }

        public List<Trainer> GetAllTrainers()
        {
            return _repository.Trainers.ToList();
        }

        public List<Trainers_Training> GetAllTrainersTrainings()
        {
            return _repository.TrainersTrainings.ToList();
        }

        public List<Training> GetAllTrainings()
        {
            return _repository.Trainings.ToList();
        }

        public List<Training> FilterTrainings(string partition)
        {
            return _repository.Trainings.Where(p => p.Partition == partition).ToList();
        }

        public Training GetByIdTraining(int id)
        {
            return _repository.Trainings.FirstOrDefault(p => p.ID == id);
        }

        public void SaveTraining(Training model)
        {
            if (model.ID == 0)
                _context.Trainings.Add(model);
            else
            {
                Training dbEntry = _context.Trainings.Find(model.ID);
                if (dbEntry != null)
                {
                    dbEntry.TrainingName = model.TrainingName;
                    dbEntry.About = model.About;
                    dbEntry.Partition = model.Partition;
                    dbEntry.TrainingType = model.TrainingType;
                }
            }
            _context.SaveChanges();
        }

        public void DeleteTraining(int id)
        {
            Training dbEntry = _context.Trainings.Find(id);
            if (dbEntry != null)
            {
                _context.Trainings.Remove(dbEntry);
                _context.SaveChanges();
            }
        }
    }
}