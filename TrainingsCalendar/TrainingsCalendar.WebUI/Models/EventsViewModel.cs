using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainingsCalendar.WebUI.Models
{
    public class EventsViewModel
    {
        public int ID { get; set; }

        public int TrainingID { get; set; }
        public string Training { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string ColorPast { get; set; }

        public string ColorFuture { get; set; }

        public List<TrainingList> TrainingList { get; set; }
    }
}