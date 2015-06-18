using System;

namespace TrainingsCalendar.WebUI.Models
{
    public class MonthViewModel
    {
        public int MonthInt { get; set; }
        public string MonthString { get; set; }
        public int Year { get; set; }
        public int DaysInMonth { get; set; }
    }
}