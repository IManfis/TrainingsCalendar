using System;

namespace TrainingsCalendar.Domain.Model
{
    public class DateModel
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Month { get; set; }
    }
}
