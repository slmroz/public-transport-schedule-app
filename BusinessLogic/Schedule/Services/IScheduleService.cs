using BusinessLogic.Schedule.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Schedule.Services
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleItemDTO>> GetScheduleItemList(int busStopId, TimeSpan baseTime);
    }
}
