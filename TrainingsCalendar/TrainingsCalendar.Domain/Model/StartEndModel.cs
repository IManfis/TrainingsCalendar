using System;

namespace TrainingsCalendar.Domain.Model
{
    public class StartEndModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Month { get; set; }
        public int DaysInMonth { get; set; }
    }
}
