using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TrainingsCalendar.Domain.Abstract;
using TrainingsCalendar.Domain.Entities;
using TrainingsCalendar.Domain.Model;

namespace TrainingsCalendar.Domain.Concrete
{
    public class TrainingsStore : ITrainingsStore
    {
        private readonly ITrainingsRepository _repository;
        private readonly EFDbContext _context = new EFDbContext();

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
                    dbEntry.ColorPast = model.ColorPast;
                    dbEntry.ColorFuture = model.ColorFuture;
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

        public string GetStringMounth(int mounth)
        {
            string mounthS = null;
            switch (mounth)
            {
                case 1:
                    mounthS = "January";
                    break;
                case 2:
                    mounthS = "February";
                    break;
                case 3:
                    mounthS = "March";
                    break;
                case 4:
                    mounthS = "April";
                    break;
                case 5:
                    mounthS = "May";
                    break;
                case 6:
                    mounthS = "June";
                    break;
                case 7:
                    mounthS = "July";
                    break;
                case 8:
                    mounthS = "August";
                    break;
                case 9:
                    mounthS = "September";
                    break;
                case 10:
                    mounthS = "October";
                    break;
                case 11:
                    mounthS = "November";
                    break;
                case 12:
                    mounthS = "December";
                    break;
            }
            return mounthS;
        }

        public int GetIntMounth(string mounth)
        {
            int mounthS = 0;
            switch (mounth)
            {
                case "January":
                    mounthS = 1;
                    break;
                case "February":
                    mounthS = 2;
                    break;
                case "March":
                    mounthS = 3;
                    break;
                case "April":
                    mounthS = 4;
                    break;
                case "May":
                    mounthS = 5;
                    break;
                case "June":
                    mounthS = 6;
                    break;
                case "July":
                    mounthS = 7;
                    break;
                case "August":
                    mounthS = 8;
                    break;
                case "September":
                    mounthS = 9;
                    break;
                case "October":
                    mounthS = 10;
                    break;
                case "November":
                    mounthS = 11;
                    break;
                case "December":
                    mounthS = 12;
                    break;
            }
            return mounthS;
        }

        public int ChangeYearUp(int year, int month)
        {
            if (month == 1)
            {
                year += 1;
            }
            return (year);
        }

        public int ChangeYearDown(int year, int month)
        {
            if (month == 12)
            {
                year -= 1;
            }
            return (year);
        }

        public List<Event> FilterDate(string name)
        {
            return _repository.Events.Where(x => x.Training.TrainingName == name).ToList();
        }

        public DateModel PartitionEventForMonths(List<Event> events)
        {
            List<StartEndModel> datemodel = new List<StartEndModel>();
            string name = null;
            var cultureinfo = new CultureInfo("ru-RU");
            foreach (var item in events)
            {
                name = item.Training.TrainingName;
                for (var i = 1; i <= 12; i++)
                {
                    if (i >= item.StartDate.Month && i <= item.EndDate.Month)
                    {
                        if (item.EndDate.Month - item.StartDate.Month > 0 || item.EndDate.Month - item.StartDate.Month < 0)
                        {
                            if (i == item.StartDate.Month)
                            {
                                var date = new StartEndModel
                                {
                                    StartDate = item.StartDate,
                                    EndDate = DateTime.Parse(
                                            String.Format("{0}-{1}-{2}",
                                            DateTime.DaysInMonth(item.StartDate.Year, item.StartDate.Month),
                                            item.StartDate.Month,
                                            item.StartDate.Year),
                                            cultureinfo),
                                    Month = i,
                                    DaysInMonth = DateTime.DaysInMonth(item.StartDate.Year, item.StartDate.Month)
                                };
                                datemodel.Add(date);
                            }
                            if (i == item.EndDate.Month)
                            {
                                var date = new StartEndModel
                                {
                                    StartDate = DateTime.Parse(
                                            String.Format("{0}-{1}-{2}",
                                            1,
                                            item.EndDate.Month,
                                            item.EndDate.Year),
                                            cultureinfo),
                                    EndDate = item.EndDate,
                                    Month = i,
                                    DaysInMonth = DateTime.DaysInMonth(item.EndDate.Year, item.EndDate.Month)
                                };
                                datemodel.Add(date);
                            }
                            if (i != item.StartDate.Month && i != item.EndDate.Month)
                            {
                                var date = new StartEndModel
                                {
                                    StartDate = DateTime.Parse(
                                            String.Format("{0}-{1}-{2}",
                                            1,
                                            i,
                                            item.EndDate.Year),
                                            cultureinfo),
                                    EndDate = DateTime.Parse(
                                            String.Format("{0}-{1}-{2}",
                                            DateTime.DaysInMonth(item.EndDate.Year, i),
                                            i,
                                            item.EndDate.Year),
                                            cultureinfo),
                                    Month = i,
                                    DaysInMonth = DateTime.DaysInMonth(item.EndDate.Year,i)
                                };
                                datemodel.Add(date);
                            }
                        }
                        else
                        {
                            var date = new StartEndModel
                            {
                                StartDate = item.StartDate,
                                EndDate = item.EndDate,
                                Month = i,
                                DaysInMonth = DateTime.DaysInMonth(item.StartDate.Year, item.StartDate.Month)
                            };
                            datemodel.Add(date);
                        }   
                    }
                }
            }
            var model = new DateModel { Name = name, StartEndModels = datemodel };
            return (model);
        }
    }
}