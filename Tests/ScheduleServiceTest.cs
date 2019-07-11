using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Repository;
using System.Linq;
using BusinessLogic.Schedule.Services;
using BusinessLogic.Schedule.Logic;

namespace Tests
{
    [TestClass]
    public class ScheduleServiceTest
    {
        private ITimeCalculator _timeCalculator;
        private IRouteRepository _routeRepository;
        private IBusStopRepository _busStopRepository;
        private IScheduleRepository _scheduleRepository;
        private IScheduleService _scheduleService;

        [TestInitialize]
        public void TestInit()
        {
            _timeCalculator = new TimeCalculator();
            _routeRepository = new RouteRepository();
            _busStopRepository = new BusStopRepository();
            _scheduleRepository = new ScheduleRepository(_routeRepository, _busStopRepository);
            _scheduleService = new ScheduleService(_scheduleRepository, _timeCalculator);
        }

        [TestMethod]
        public void ScheduleServiceReturnsProperDepartureTimes()
        {
            var mockBusStopId = 1;
            var mockBaseTime = new TimeSpan(0, 14, 0);
            var route1Id = 1;
            var expectedDepartureTimeNumber = 2;
            var expectedFirstTime = 1D;
            var expectedSecondTime = 16D;

            var result = _scheduleService.GetScheduleItemList(mockBusStopId, mockBaseTime);

            var route1 = result.Result.FirstOrDefault(r => r.Route.Id == route1Id);

            Assert.IsNotNull(route1);

            if (route1 != null) {

                var route1Times = route1.Departures.OrderBy(r => r).ToList();

                Assert.AreEqual(route1Times.Count, expectedDepartureTimeNumber);
                Assert.AreEqual(route1Times.First(), expectedFirstTime);
                Assert.AreEqual(route1Times.Last(), expectedSecondTime);
            }
        }
    }
}
