using System.Collections.Generic;

namespace TrainingsCalendar.WebUI.Models
{
    public class CalendarViewModel
    {
        public List<DateViewModel> DateViewModels { get; set; }
        public List<MonthViewModel> MonthViewModel { get; set; }
    }
}