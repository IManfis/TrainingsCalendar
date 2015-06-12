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
                string mounth = null;
                switch (item.StartDate.Month)
                {
                    case 1:
                        mounth = "January";
                        break;
                    case 2:
                        mounth = "February";
                        break;
                    case 3:
                        mounth = "March";
                        break;
                    case 4:
                        mounth = "April";
                        break;
                    case 5:
                        mounth = "May";
                        break;
                    case 6:
                        mounth = "June";
                        break;
                    case 7:
                        mounth = "July";
                        break;
                    case 8:
                        mounth = "August";
                        break;
                    case 9:
                        mounth = "September";
                        break;
                    case 10:
                        mounth = "October";
                        break;
                    case 11:
                        mounth = "November";
                        break;
                    case 12:
                        mounth = "December";
                        break;
                }
                list.Add(new CalendarViewModel { TrainingName = item.Training.TrainingName, StartDate = item.StartDate.Day, EndDate = item.EndDate.Day, Mounth = mounth, DaysInMonth = DateTime.DaysInMonth(item.StartDate.Year, item.StartDate.Month) });
            }
            return View(list);
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
