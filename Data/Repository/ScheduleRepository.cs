using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ScheduleRepository: IScheduleRepository
    {
        private List<ScheduleItem> _allScheduleItems;
        private IRouteRepository _routeRepository;
        private IBusStopRepository _busStopRepository;

        public ScheduleRepository(IRouteRepository routeRepository, IBusStopRepository busStopRepository)
        {
            _routeRepository = routeRepository;
            _busStopRepository = busStopRepository;

            //mocking bus stop list
            _allScheduleItems = new List<ScheduleItem>();
            var busStopList = _busStopRepository.GetAll();
            var routeList = _routeRepository.GetAll();

            foreach (var route in routeList.Result)
            {
                foreach (var busStop in busStopList.Result)
                {
                    _allScheduleItems.Add(new ScheduleItem()
                    {
                        Route = route,
                        BusStop = busStop,
                        Departures = GetDepartureTimes(route, busStop)
                    });
                }
            }
        }

        public async Task<IQueryable<ScheduleItem>> GetAll()
        {
            IQueryable<ScheduleItem> query = _allScheduleItems.AsQueryable();
            return query;
        }

        public IQueryable<ScheduleItem> FindBy(Expression<Func<ScheduleItem, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(ScheduleItem entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ScheduleItem entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(ScheduleItem entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        // mock method generating departure times for the combination od bus stop and route
        private List<TimeSpan> GetDepartureTimes(Route route, BusStop busStop)
        {
            const int StopIntervalInMinutes = 15;
            const int RouteIntervalInMinutes = 2;

            var retValue = new List<TimeSpan>();

            var stopTime = new TimeSpan(
                0,
                ((route.Id - 1) * RouteIntervalInMinutes + (busStop.Id - 1) * RouteIntervalInMinutes) % StopIntervalInMinutes,
                0);

            while (stopTime < new TimeSpan(24, 0, 0))
            {
                retValue.Add(stopTime);
                stopTime = stopTime.Add(new TimeSpan(0, StopIntervalInMinutes, 0));
            }

            return retValue;
        }
    }
}
