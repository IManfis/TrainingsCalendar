using System.ComponentModel.DataAnnotations;

namespace TrainingsCalendar.Domain.Entities
{
    public class Trainers_Training
    {
        [Key]
        public int ID { get; set; }

        public int TrainingID { get; set; }
        public virtual Training Training { get; set; }

        public int TrainersID { get; set; }
        public virtual Trainer Trainers { get; set; }
    }
}
