using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using TrainingsCalendar.Domain.Abstract;
using TrainingsCalendar.Domain.Entities;
using TrainingsCalendar.WebUI.Models;

namespace TrainingsCalendar.WebUI.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private readonly ITrainingsStore _store;

        public AdminController(ITrainingsStore store)
        {
            _store = store;
        }

        public ActionResult AdminPanel()
        {
            return View();
        }

        [HttpGet]
        public ViewResult TrainingList()
        {
            Mapper.CreateMap<Training, TrainingsViewModel>();
            var users = Mapper.Map<IEnumerable<Training>, List<TrainingsViewModel>>(_store.GetAllTrainings());
            return View(users);
        }

        public ViewResult EditTraining(int id)
        {
            Mapper.CreateMap<Training, TrainingsViewModel>();
            var users = Mapper.Map<Training, TrainingsViewModel>(_store.GetByIdTraining(id));
            return View(users);
        }

        [HttpPost]
        public ActionResult EditTraining(TrainingsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<TrainingsViewModel, Training>();

                var users = Mapper.Map<TrainingsViewModel, Training>(model);
                _store.SaveTraining(users);
                return RedirectToAction("TrainingList");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(model);
            }
        }

        public ViewResult CreateTraining()
        {
            return View("EditTraining",new TrainingsViewModel());
        }

        public ActionResult DeleteTraining(int id)
        {
            Mapper.CreateMap<Training, TrainingsViewModel>();

            var users = Mapper.Map<Training, TrainingsViewModel>(_store.GetByIdTraining(id));
            _store.DeleteTraining(id);

            Mapper.CreateMap<Training, TrainingsViewModel>();

            var users1 = Mapper.Map<IEnumerable<Training>, List<TrainingsViewModel>>(_store.GetAllTrainings());

            return View("TrainingList", users1);
        }
    }
}
