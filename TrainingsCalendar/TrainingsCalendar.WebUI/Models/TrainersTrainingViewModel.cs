using System.Collections.Generic;

namespace TrainingsCalendar.WebUI.Models
{
    public class TrainersTrainingViewModel
    {
        public int ID { get; set; }
        public int TrainingID { get; set; }
        public string Training { get; set; }
        public int TrainersID { get; set; }
        public string Trainer { get; set; }

        public List<TrainingList> TrainingLists { get; set; }
        public List<TrainersList> TrainersLists { get; set; }
    }
}