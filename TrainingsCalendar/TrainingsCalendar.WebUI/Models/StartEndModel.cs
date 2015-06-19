using System;
using System.Collections.Generic;

namespace TrainingsCalendar.WebUI.Models
{
    public class StartEndModel
    {
        public int TrainingID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<TrainingList> TrainingList { get; set; }
    }
}