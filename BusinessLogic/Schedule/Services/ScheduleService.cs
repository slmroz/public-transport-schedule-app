using BusinessLogic.Schedule.DTO;
using BusinessLogic.Schedule.Logic;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Schedule.Services
{
    public class ScheduleService : IScheduleService
    {
        private IScheduleRepository _repository;
        private ITimeCalculator _timeCalculator;

        private const int SearchCount = 2;

        public ScheduleService(IScheduleRepository repository, ITimeCalculator timeCalculator)
        {
            _repository = repository;
            _timeCalculator = timeCalculator;
        }

        // get all the routes, each with 2 closest departure times
        // params: busStopId - Id of the selected bus stop, baseTime - TimeSpan for comparison
        public async Task<IEnumerable<ScheduleItemDTO>> GetScheduleItemList(int busStopId, TimeSpan baseTime)
        {
            var retValue = new List<ScheduleItemDTO>();

            var scheduleListQuery = await _repository.GetAll().ConfigureAwait(false);
            var routes = scheduleListQuery
                .Where(s => s.BusStop.Id == busStopId).ToList();

            foreach(var route in routes)
            {
                var routeToBeAdded = new ScheduleItemDTO()
                {
                    Route = route.Route,
                    Departures = route
                            .Departures
                            .Where(d => d > baseTime)
                            .OrderBy(d => d)
                            .Select(d => _timeCalculator.CalculateDepartureTimeDifference(d, baseTime))
                            .Take(SearchCount).ToList()
                };

                // checking if midnight approaches and there are no two remaining repartures
                var departureCount = routeToBeAdded.Departures.Count;
                if (departureCount < 2)
                {
                    routeToBeAdded.Departures.AddRange(
                         route
                            .Departures
                            .OrderBy(d => d)
                            .Select(d => _timeCalculator.CalculateDepartureTimeDifference(d, baseTime))
                            .Take(SearchCount - departureCount).ToList()
                    );
                }

                retValue.Add(routeToBeAdded);
            }

            return retValue;
        }
    }
}
