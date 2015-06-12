using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            List<CalendarViewModel> list = new List<CalendarViewModel>();
            foreach (var item in _repository.GetAllEvents())
            {
                string mounth = _repository.GetStringMounth(DateTime.Now.Month);
                if (item.StartDate.Month == DateTime.Now.Month)
                {
                    list.Add(new CalendarViewModel
                    {
                        TrainingName = item.Training.TrainingName,
                        StartDate = item.StartDate.Day,
                        EndDate = item.EndDate.Day,
                        Mounth = mounth,
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
                        DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)
                    });
                }
            }
            return View(list);
        }

        public ViewResult PrevMounth(string mounth)
        {
            int m = _repository.GetIntMounth(mounth);
            string mounthS = _repository.GetStringMounth(m - 1);
            List<CalendarViewModel> list = new List<CalendarViewModel>();
            foreach (var item in _repository.GetAllEvents())
            {
                if (item.StartDate.Month == m - 1)
                {
                    list.Add(new CalendarViewModel
                    {
                        TrainingName = item.Training.TrainingName,
                        StartDate = item.StartDate.Day,
                        EndDate = item.EndDate.Day,
                        Mounth = mounthS,
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
                        Mounth = mounthS,
                        DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)
                    });
                }
            }
            return View("Index",list);
        }


        public ViewResult NextMounth(string mounth)
        {
            int m = _repository.GetIntMounth(mounth);
            string mounthS = _repository.GetStringMounth(m + 1);
            List<CalendarViewModel> list = new List<CalendarViewModel>();
            foreach (var item in _repository.GetAllEvents())
            {
                if (item.StartDate.Month == m + 1)
                {
                    list.Add(new CalendarViewModel
                    {
                        TrainingName = item.Training.TrainingName,
                        StartDate = item.StartDate.Day,
                        EndDate = item.EndDate.Day,
                        Mounth = mounthS,
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
                        Mounth = mounthS,
                        DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)
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
