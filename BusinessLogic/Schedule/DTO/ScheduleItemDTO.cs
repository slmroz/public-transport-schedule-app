using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Schedule.DTO
{
    public class ScheduleItemDTO
    {
        public Route Route { get; set; }
        public List<double> Departures { get; set; }
    }
}
