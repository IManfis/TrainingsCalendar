using System.Collections.Generic;
using System.Linq;
using TrainingsCalendar.Domain.Abstract;
using TrainingsCalendar.Domain.Entities;

namespace TrainingsCalendar.Domain.Concrete
{
    public class TrainingsStore : ITrainingsStore
    {
        private readonly ITrainingsRepository _repository;

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
    }
}