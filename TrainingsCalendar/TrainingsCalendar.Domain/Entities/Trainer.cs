using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainingsCalendar.Domain.Entities
{
    public class Trainer
    {
        public Trainer()
        {
            this.TrainersTraining = new HashSet<Trainers_Training>();
        }

        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Trainers_Training> TrainersTraining { get; set; }
    }
}
