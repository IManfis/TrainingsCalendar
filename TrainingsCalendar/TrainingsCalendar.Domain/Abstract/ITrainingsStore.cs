using System;
using System.Collections.Generic;
using TrainingsCalendar.Domain.Entities;
using TrainingsCalendar.Domain.Model;

namespace TrainingsCalendar.Domain.Abstract
{
    public interface ITrainingsStore
    {
        List<Event> GetAllEvents();
        List<Trainer> GetAllTrainers();
        List<Trainers_Training> GetAllTrainersTrainings();
        List<Training> GetAllTrainings();

        List<Training> FilterTrainings(string partition);
        Training GetByIdTraining(int id);
        void SaveTraining(Training model);
        void DeleteTraining(int id);

        Trainer GetByIdTrainer(int id);
        void SaveTrainer(Trainer model);
        void DeleteTrainer(int id);

        Event GetByIdEvent(int id);
        void SaveEvent(Event model);
        void DeleteEvent(int id);

        Trainers_Training GetByIdTrainersTraining(int id);
        void SaveTrainersTraining(Trainers_Training model);
        void DeleteTrainersTraining(int id);

        string GetStringMounth(int mounth);
        int GetIntMounth(string mounth);
        DateModel PartitionEventForMonths(DateTime start, DateTime end, int mounth);
        int ChangeYearUp(int year, int month);
        int ChangeYearDown(int year, int month);
    }
}