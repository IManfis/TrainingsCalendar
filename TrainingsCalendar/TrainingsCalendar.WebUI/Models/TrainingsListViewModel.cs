using System.Collections.Generic;
using TrainingsCalendar.Domain.Entities;

namespace TrainingsCalendar.WebUI.Models
{
    public class TrainingsListViewModel
    {
        public ICollection<Training> TrainingName { get; set; }
        public string Partition { get; set; }
    }
}