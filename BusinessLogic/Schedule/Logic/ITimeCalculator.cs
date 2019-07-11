using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Schedule.Logic
{
    public interface ITimeCalculator
    {
        double CalculateDepartureTimeDifference(TimeSpan departureTime, TimeSpan baseTime);
    }
}
