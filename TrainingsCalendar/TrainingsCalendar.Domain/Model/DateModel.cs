using System;
using System.Collections.Generic;

namespace TrainingsCalendar.Domain.Model
{
    public class DateModel
    {
        public string Name { get; set; }
        public List<StartEndModel> StartEndModels { get; set; }
    }
}
