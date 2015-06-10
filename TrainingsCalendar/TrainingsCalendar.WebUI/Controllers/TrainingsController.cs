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
            return View();
        }


        public PartialViewResult List()
        {
            ICollection<TrainingsListViewModel> model = new Collection<TrainingsListViewModel>();
            foreach (var item in _repository.GetAllTrainings())
            {
                if (!model.Any())
                {
                    var list = new TrainingsListViewModel { Partition = item.Partition, TrainingName = _repository.FilterTrainings(item.Partition) };
                    model.Add(list);
                }else if (item.Partition != model.Last().Partition)
                {
                    var list = new TrainingsListViewModel { Partition = item.Partition, TrainingName = _repository.FilterTrainings(item.Partition) };
                    model.Add(list);
                }
            }
            return PartialView(model);
        }

    }
}
