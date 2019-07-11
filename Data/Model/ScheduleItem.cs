using System;
using System.Collections.Generic;

namespace Data.Model
{
    public class ScheduleItem
    {
        public BusStop BusStop { get; set; }
        public Route Route { get; set; }
        public List<TimeSpan> Departures { get; set; }
    }
}
