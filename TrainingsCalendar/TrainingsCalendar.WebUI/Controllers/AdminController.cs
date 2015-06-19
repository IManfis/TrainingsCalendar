using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using TrainingsCalendar.Domain.Abstract;
using TrainingsCalendar.Domain.Entities;
using TrainingsCalendar.WebUI.Models;

namespace TrainingsCalendar.WebUI.Controllers
{
    [Authorize]
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
            List<string> list = Enum.GetNames(typeof(KnownColor)).Where(item => !item.StartsWith("Control")).OrderBy(item => item).Select(c => c.ToLower()).ToList();
            Mapper.CreateMap<Training, TrainingsViewModel>();
            var users = Mapper.Map<Training, TrainingsViewModel>(_store.GetByIdTraining(id));
            users.ColorList = list;
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
            List<string> list = Enum.GetNames(typeof(KnownColor)).Where(item => !item.StartsWith("Control")).OrderBy(item => item).Select(c => c.ToLower()).ToList();
            return View("EditTraining",new TrainingsViewModel{ColorList = list});
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

        [HttpGet]
        public ViewResult TrainersList()
        {
            Mapper.CreateMap<Trainer, TrainersViewModel>();
            var users = Mapper.Map<IEnumerable<Trainer>, List<TrainersViewModel>>(_store.GetAllTrainers());
            return View(users);
        }

        public ViewResult EditTrainers(int id)
        {
            Mapper.CreateMap<Trainer, TrainersViewModel>();
            var users = Mapper.Map<Trainer, TrainersViewModel>(_store.GetByIdTrainer(id));
            return View(users);
        }

        [HttpPost]
        public ActionResult EditTrainers(TrainersViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<TrainersViewModel, Trainer>();

                var users = Mapper.Map<TrainersViewModel, Trainer>(model);
                _store.SaveTrainer(users);
                return RedirectToAction("TrainersList");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(model);
            }
        }

        public ViewResult CreateTrainers()
        {
            return View("EditTrainers", new TrainersViewModel());
        }

        public ActionResult DeleteTrainers(int id)
        {
            Mapper.CreateMap<Trainer, TrainersViewModel>();

            var users = Mapper.Map<Trainer, TrainersViewModel>(_store.GetByIdTrainer(id));
            _store.DeleteTrainer(id);

            Mapper.CreateMap<Trainer, TrainersViewModel>();

            var users1 = Mapper.Map<IEnumerable<Trainer>, List<TrainersViewModel>>(_store.GetAllTrainers());

            return View("TrainersList", users1);
        }

        [HttpGet]
        public ViewResult EventsList()
        {
            Mapper.CreateMap<Event, EventsViewModel>()
                .ForMember(x => x.TrainingName, x => x.MapFrom(m => m.Training.TrainingName))
                .ForMember(x => x.ColorPast, x => x.MapFrom(m => m.Training.ColorPast))
                .ForMember(x => x.ColorFuture, x => x.MapFrom(m => m.Training.ColorFuture));
            var users = Mapper.Map<IEnumerable<Event>, List<EventsViewModel>>(_store.GetAllEvents());
            return View(users);
        }

        public ViewResult EditEvents(int id)
        {
            Mapper.CreateMap<Event, EventsViewModel>()
                .ForMember(x => x.TrainingName, x => x.MapFrom(m => m.Training.TrainingName));
            var users = Mapper.Map<Event, EventsViewModel>(_store.GetByIdEvent(id));
            return View(users);
        }

        [HttpPost]
        public ActionResult EditEvents(EventsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<EventsViewModel, Event>();

                var users = Mapper.Map<EventsViewModel, Event>(model);
                _store.SaveEvent(users);
                return RedirectToAction("EventsList");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(model);
            }
        }

        public ViewResult CreateEvents()
        {
            Mapper.CreateMap<Training, TrainingList>()
                .ForMember(x => x.TrainingID, x => x.MapFrom(m => m.ID))
                .ForMember(x => x.TrainingName, x => x.MapFrom(m => m.TrainingName));
            var users = Mapper.Map<IEnumerable<Training>, List<TrainingList>>(_store.GetAllTrainings());
            var model = new StartEndModel {TrainingList = users};
            var events = new List<StartEndModel>();
            events.Add(model);
            return View(events);
        }
        [HttpPost]
        public ActionResult CreateEvents(List<StartEndModel> model)
        {
            var id = model.ElementAt(0).TrainingID;
            foreach (var item in model)
            {
                if (item.StartDate.Year != 1 && item.EndDate.Year != 1)
                {
                    var users = new Event
                    {
                        TrainingID = id,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate
                    };
                    _store.SaveEvent(users);
                }
            }
            
            return RedirectToAction("EventsList");
        }

        public ActionResult DeleteEvents(int id)
        {
            Mapper.CreateMap<Event, EventsViewModel>();

            var users = Mapper.Map<Event, EventsViewModel>(_store.GetByIdEvent(id));
            _store.DeleteEvent(id);

            Mapper.CreateMap<Event, EventsViewModel>();

            var users1 = Mapper.Map<IEnumerable<Event>, List<EventsViewModel>>(_store.GetAllEvents());

            return View("EventsList", users1);
        }

        [HttpGet]
        public ViewResult TrainersTrainingList()
        {
            Mapper.CreateMap<Trainers_Training, TrainersTrainingViewModel>()
                .ForMember(x => x.Trainer, x => x.MapFrom(m => m.Trainers.LastName + " " + m.Trainers.FirstName))
                .ForMember(x => x.Training, x => x.MapFrom(m => m.Training.TrainingName));
            var users = Mapper.Map<IEnumerable<Trainers_Training>, List<TrainersTrainingViewModel>>(_store.GetAllTrainersTrainings());
            return View(users);
        }

        public ViewResult EditTrainersTraining(int id)
        {
            Mapper.CreateMap<Trainers_Training, TrainingList>()
                .ForMember(x => x.TrainingID, x => x.MapFrom(m => m.TrainingID))
                .ForMember(x => x.TrainingName, x => x.MapFrom(m => m.Training.TrainingName));
            var users = Mapper.Map<Trainers_Training, TrainingList>(_store.GetByIdTrainersTraining(id));

            Mapper.CreateMap<Trainers_Training, TrainersList>()
                .ForMember(x => x.TrainersID, x => x.MapFrom(m => m.TrainersID))
                .ForMember(x => x.FirstName, x => x.MapFrom(m => m.Trainers.FirstName))
                .ForMember(x => x.LastName, x => x.MapFrom(m => m.Trainers.LastName));
            var users1 = Mapper.Map<IEnumerable<Trainers_Training>, List<TrainersList>>(_store.GetAllTrainersTrainings());

            return View(new TrainersTrainingViewModel{TrainersLists = users1,Training = users.TrainingName, TrainingID = users.TrainingID});
        }

        [HttpPost]
        public ActionResult EditTrainersTraining(TrainersTrainingViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<TrainersTrainingViewModel, Trainers_Training>();

                var users = Mapper.Map<TrainersTrainingViewModel, Trainers_Training>(model);
                _store.SaveTrainersTraining(users);
                return RedirectToAction("TrainersTrainingList");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(model);
            }
        }

        public ViewResult CreateTrainersTraining()
        {
            Mapper.CreateMap<Training, TrainingList>()
                .ForMember(x => x.TrainingID, x => x.MapFrom(m => m.ID))
                .ForMember(x => x.TrainingName, x => x.MapFrom(m => m.TrainingName));
            var users = Mapper.Map<IEnumerable<Training>, List<TrainingList>>(_store.GetAllTrainings());

            Mapper.CreateMap<Trainer, TrainersList>()
                .ForMember(x => x.TrainersID, x => x.MapFrom(m => m.ID))
                .ForMember(x => x.FirstName, x => x.MapFrom(m => m.FirstName))
                .ForMember(x => x.LastName, x => x.MapFrom(m => m.LastName));
            var users1 = Mapper.Map<IEnumerable<Trainer>, List<TrainersList>>(_store.GetAllTrainers());
            return View(new TrainersTrainingViewModel { TrainersLists = users1, TrainingLists = users});
        }

        public ActionResult DeleteTrainersTraining(int id)
        {
            Mapper.CreateMap<Trainers_Training, TrainersTrainingViewModel>();

            var users = Mapper.Map<Trainers_Training, TrainersTrainingViewModel>(_store.GetByIdTrainersTraining(id));
            _store.DeleteTrainersTraining(id);

            Mapper.CreateMap<Trainers_Training, TrainersTrainingViewModel>();

            var users1 = Mapper.Map<IEnumerable<Trainers_Training>, List<TrainersTrainingViewModel>>(_store.GetAllTrainersTrainings());

            return View("TrainersTrainingList", users1);
        }
    }
}
