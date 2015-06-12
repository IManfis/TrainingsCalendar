using System;

namespace TrainingsCalendar.WebUI.Models
{
    public class CalendarViewModel
    {
        public string TrainingName { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public int DaysInMonth { get; set; }
        public int Mounth { get; set; }
    }
}