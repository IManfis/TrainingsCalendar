using System.Collections.Generic;
using TrainingsCalendar.Domain.Model;

namespace TrainingsCalendar.WebUI.Models
{
    public class DateViewModel
    {
        public DateModel DateModels { get; set; }
        public string ColorPast { get; set; }
        public string ColorFuture { get; set; }
    }
}