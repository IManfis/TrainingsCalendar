using System.ComponentModel.DataAnnotations;

namespace TrainingsCalendar.WebUI.Models
{
    public class TrainersViewModel
    {
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; } 
    }
}