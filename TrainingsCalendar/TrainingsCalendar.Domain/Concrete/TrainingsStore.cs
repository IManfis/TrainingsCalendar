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

        public Trainer GetByIdTrainer(int id)
        {
            return _repository.Trainers.FirstOrDefault(p => p.ID == id);
        }

        public void SaveTrainer(Trainer model)
        {
            if (model.ID == 0)
                _context.Trainers.Add(model);
            else
            {
                Trainer dbEntry = _context.Trainers.Find(model.ID);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = model.FirstName;
                    dbEntry.LastName = model.LastName;
                }
            }
            _context.SaveChanges();
        }

        public void DeleteTrainer(int id)
        {
            Trainer dbEntry = _context.Trainers.Find(id);
            if (dbEntry != null)
            {
                _context.Trainers.Remove(dbEntry);
                _context.SaveChanges();
            }
        }

        public Event GetByIdEvent(int id)
        {
            return _repository.Events.FirstOrDefault(p => p.ID == id);
        }

        public void SaveEvent(Event model)
        {
            if (model.ID == 0)
                _context.Events.Add(model);
            else
            {
                Event dbEntry = _context.Events.Find(model.ID);
                if (dbEntry != null)
                {
                    dbEntry.StartDate = model.StartDate;
                    dbEntry.EndDate = model.EndDate;
                }
            }
            _context.SaveChanges();
        }

        public void DeleteEvent(int id)
        {
            Event dbEntry = _context.Events.Find(id);
            if (dbEntry != null)
            {
                _context.Events.Remove(dbEntry);
                _context.SaveChanges();
            }
        }

        public Trainers_Training GetByIdTrainersTraining(int id)
        {
            return _repository.TrainersTrainings.FirstOrDefault(p => p.ID == id);
        }

        public void SaveTrainersTraining(Trainers_Training model)
        {
            if (model.ID == 0)
                _context.TrainersTrainings.Add(model);
            else
            {
                Trainers_Training dbEntry = _context.TrainersTrainings.Find(model.ID);
                if (dbEntry != null)
                {
                    dbEntry.TrainersID = model.TrainersID;
                    dbEntry.TrainingID = model.TrainingID;
                }
            }
            _context.SaveChanges();
        }

        public void DeleteTrainersTraining(int id)
        {
            Trainers_Training dbEntry = _context.TrainersTrainings.Find(id);
            if (dbEntry != null)
            {
                _context.TrainersTrainings.Remove(dbEntry);
                _context.SaveChanges();
            }
        }
    }
}