using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainingsCalendar.Domain.Entities
{
    public class Training
    {
        public Training()
        {
            this.Event = new HashSet<Event>();
            this.Trainers_Training = new HashSet<Trainers_Training>();
        }

        [Key]
        public int ID { get; set; }

        public string TrainingName { get; set; }

        public string About { get; set; }

        public string Partition { get; set; }

        public string TrainingType { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Trainers_Training> Trainers_Training { get; set; }
    }
}
