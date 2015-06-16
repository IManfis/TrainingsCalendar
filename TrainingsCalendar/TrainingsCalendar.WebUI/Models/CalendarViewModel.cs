﻿using System;

namespace TrainingsCalendar.WebUI.Models
{
    public class CalendarViewModel
    {
        public string TrainingName { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public int DaysInMonth { get; set; }
        public string Mounth { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int NowDay { get; set; }
    }
}