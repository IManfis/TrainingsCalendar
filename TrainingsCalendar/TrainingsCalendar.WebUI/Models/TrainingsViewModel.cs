using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainingsCalendar.WebUI.Models
{
    public class TrainingsViewModel
    {
        public int ID { get; set; }

        [Required]
        public string TrainingName { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string About { get; set; }

        [Required]
        public string Partition { get; set; }

        [Required]
        public string TrainingType { get; set; }

        public string ColorPast { get; set; }

        public string ColorFuture { get; set; }

        public List<string> ColorList { get; set; }  
    }
}