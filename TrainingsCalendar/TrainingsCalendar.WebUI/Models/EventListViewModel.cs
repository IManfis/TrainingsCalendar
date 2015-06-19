using System;
using System.Collections.Generic;

namespace TrainingsCalendar.WebUI.Models
{
    public class EventListViewModel
    {
        public int TrainingID { get; set; }
        public List<StartEndModel> StartEndModels { get; set; } 
        public List<TrainingList> TrainingList { get; set; }
    }
}