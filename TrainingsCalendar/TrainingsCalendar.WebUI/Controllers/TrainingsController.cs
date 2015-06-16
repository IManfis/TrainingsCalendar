using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TrainingsCalendar.Domain.Abstract;
using TrainingsCalendar.WebUI.Models;

namespace TrainingsCalendar.WebUI.Controllers
{
    public class TrainingsController : Controller
    {
        //
        // GET: /Trainings/
        private readonly ITrainingsStore _repository;

        public TrainingsController(ITrainingsStore repository)
        {
            _repository = repository;
        }

        public ViewResult Index()
        {
            var list = new List<CalendarViewModel>();
            foreach (var item in _repository.GetAllEvents())
            {
                var model = _repository.PartitionEventForMonths(item.StartDate, item.EndDate, DateTime.Now.Month);
                var mounth = _repository.GetStringMounth(DateTime.Now.Month);
                if (model.Month == DateTime.Now.Month)
                {
                    list.Add(new CalendarViewModel
                    {
                        TrainingName = item.Training.TrainingName,
                        StartDate = model.StartDate.Day,
                        EndDate = model.EndDate.Day,
                        Mounth = mounth,
                        Month = DateTime.Now.Month,
                        Year = DateTime.Now.Year,
                        DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month),
                        NowDay = DateTime.Now.Day
                    });
                }
                else
                {
                    list.Add(new CalendarViewModel
                    {
                        TrainingName = item.Training.TrainingName,
                        StartDate = 1,
                        EndDate = 0,
                        Mounth = mounth,
                        Month = DateTime.Now.Month,
                        Year = DateTime.Now.Year,
                        DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)
                    });
                }
            }
            return View(list);
        }

        public ViewResult PrevMounth(string mounth, int year)
        {
            var m = _repository.GetIntMounth(mounth);
            if (m == 1)
            {
                m = 13;
            }
            var monthS = _repository.GetStringMounth(m - 1);
            var list = new List<CalendarViewModel>();
            foreach (var item in _repository.GetAllEvents())
            {
                var model = _repository.PartitionEventForMonths(item.StartDate, item.EndDate, m - 1);
                if (model.Month == m - 1)
                {
                    list.Add(new CalendarViewModel
                    {
                        TrainingName = item.Training.TrainingName,
                        StartDate = model.StartDate.Day,
                        EndDate = model.EndDate.Day,
                        Mounth = monthS,
                        Month = m - 1,
                        Year = _repository.ChangeYearDown(year,m - 1),
                        DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, m - 1),
                        NowDay = DateTime.Now.Day
                    });
                }
                else
                {
                    list.Add(new CalendarViewModel
                    {
                        TrainingName = item.Training.TrainingName,
                        StartDate = 1,
                        EndDate = 0,
                        Mounth = monthS,
                        Month = m - 1,
                        Year = _repository.ChangeYearDown(year, m - 1),
                        DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, m - 1)
                    });
                }
            }
            return View("Index",list);
        }


        public ViewResult NextMounth(string mounth, int year)
        {
            var m = _repository.GetIntMounth(mounth);
            if (m == 12)
            {
                m = 0;
            }
            var mounthS = _repository.GetStringMounth(m + 1);
            var list = new List<CalendarViewModel>();
            foreach (var item in _repository.GetAllEvents())
            {
                var model = _repository.PartitionEventForMonths(item.StartDate, item.EndDate, m + 1);
                if (model.Month == m + 1)
                {
                    list.Add(new CalendarViewModel
                    {
                        TrainingName = item.Training.TrainingName,
                        StartDate = model.StartDate.Day,
                        EndDate = model.EndDate.Day,
                        Mounth = mounthS,
                        Month = m + 1,
                        Year = _repository.ChangeYearUp(year, m + 1),
                        DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, m + 1),
                        NowDay = DateTime.Now.Day
                    });
                }
                else
                {
                    list.Add(new CalendarViewModel
                    {
                        TrainingName = item.Training.TrainingName,
                        StartDate = 1,
                        EndDate = 0,
                        Mounth = mounthS,
                        Month = m + 1,
                        Year = _repository.ChangeYearUp(year, m + 1),
                        DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, m + 1)
                    });
                }
            }
            return View("Index", list);
        }
        //public PartialViewResult List()
        //{
        //    ICollection<TrainingsListViewModel> model = new Collection<TrainingsListViewModel>();
        //    foreach (var item in _repository.GetAllTrainings())
        //    {
        //        if (!model.Any())
        //        {
        //            var list = new TrainingsListViewModel { Partition = item.Partition, TrainingName = _repository.FilterTrainings(item.Partition) };
        //            model.Add(list);
        //        }else if (item.Partition != model.Last().Partition)
        //        {
        //            var list = new TrainingsListViewModel { Partition = item.Partition, TrainingName = _repository.FilterTrainings(item.Partition) };
        //            model.Add(list);
        //        }
        //    }
        //    return PartialView(model);
        //}

    }
}
