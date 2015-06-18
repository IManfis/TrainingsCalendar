using System;
using System.Collections.Generic;
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
            var monthmodel = new List<MonthViewModel>();
            for (var i = 1; i <= 12; i++)
            {
                var month = _repository.GetStringMounth(i);
                var monthmodels = new MonthViewModel
                {
                    MonthInt = i,
                    MonthString = month,
                    Year = DateTime.Now.Year,
                    DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, i)
                };
                monthmodel.Add(monthmodels);
            }
            List<DateViewModel> datemodel = new List<DateViewModel>();
            foreach (var item in _repository.GetAllEvents().OrderBy(x => x.Training.TrainingName))
            {
                if (!datemodel.Any())
                {
                    var partial = _repository.PartitionEventForMonths(_repository.FilterDate(item.Training.TrainingName));
                    var model = new DateViewModel
                    {
                        DateModels = partial,
                        ColorPast = item.Training.ColorPast,
                        ColorFuture = item.Training.ColorFuture
                    };
                    datemodel.Add(model);  
                }
                if (datemodel.Last().DateModels.Name != item.Training.TrainingName)
                {
                    var partial = _repository.PartitionEventForMonths(_repository.FilterDate(item.Training.TrainingName));
                    var model = new DateViewModel
                    {
                        DateModels = partial,
                        ColorPast = item.Training.ColorPast,
                        ColorFuture = item.Training.ColorFuture
                    };
                    datemodel.Add(model);   
                }
            }
            var list = new CalendarViewModel { DateViewModels = datemodel, MonthViewModel = monthmodel };
            return View(list);
        }
    }
}
