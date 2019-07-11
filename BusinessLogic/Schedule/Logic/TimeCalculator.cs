using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Schedule.Logic
{
    public class TimeCalculator: ITimeCalculator
    {
        // calculates how many minutes remaining to the departure time
        public double CalculateDepartureTimeDifference(TimeSpan departureTime, TimeSpan baseTime)
        {
            if(departureTime < baseTime)
            {
                // departure time next day
                departureTime = departureTime.Add(new TimeSpan(1,0,0,0));
            }

            TimeSpan difference = departureTime - baseTime;
            // used Match.Ceiling here, could be any other rounding depending on how it needs to be implemented
            return Math.Ceiling(difference.TotalMinutes);
        }
    }
}
