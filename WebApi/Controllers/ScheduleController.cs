using BusinessLogic.Schedule.DTO;
using BusinessLogic.Schedule.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ScheduleController : ApiController
    {
        private IScheduleService _scheduleService;

        public ScheduleController(
            IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        // GET api/<controller>/5
        public async Task<IEnumerable<ScheduleItemDTO>> Get(int id)
        {
            var now = new TimeSpan(
                DateTime.Now.Hour,
                DateTime.Now.Minute,
                DateTime.Now.Second);

            var retValue = await _scheduleService.GetScheduleItemList(id, now).ConfigureAwait(false);
            return retValue;
        }
    }
}
