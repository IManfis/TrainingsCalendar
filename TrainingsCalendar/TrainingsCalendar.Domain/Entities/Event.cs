using System;
using System.ComponentModel.DataAnnotations;

namespace TrainingsCalendar.Domain.Entities
{
    public class Event
    {
        [Key]
        public int ID { get; set; }

        public int TrainingID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual Training Training { get; set; }
    }
}
