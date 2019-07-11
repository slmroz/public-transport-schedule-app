using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Repository;
using System.Linq;
using BusinessLogic.Schedule.Services;
using BusinessLogic.Schedule.Logic;

namespace Tests
{
    [TestClass]
    public class TimeCalculatorTest
    {
        private ITimeCalculator _timeCalculator;

        [TestInitialize]
        public void TestInit()
        {
            _timeCalculator = new TimeCalculator();
        }

        [TestMethod]
        public void CalculateDepartureTimeDifferenceProvidesCorrectResult()
        {
            var mockBaseTime = new TimeSpan(23, 44, 0);
            var mockDepartureTime = new TimeSpan(23, 45, 0);
            var mockDepartureTimeNextDay = new TimeSpan(0, 0, 0);

            var expectedDifference = 1D;
            var expectedDifferenceNextDay = 16D;

            var result = _timeCalculator.CalculateDepartureTimeDifference(mockDepartureTime, mockBaseTime);
            var resultNextDay = _timeCalculator.CalculateDepartureTimeDifference(mockDepartureTimeNextDay, mockBaseTime);
            Assert.AreEqual(result, expectedDifference);
            Assert.AreEqual(resultNextDay, expectedDifferenceNextDay);
        }
    }
}
