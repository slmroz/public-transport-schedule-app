using AutoMapper;
using BusinessLogic.Dictionary.Services;
using BusinessLogic.Schedule.Logic;
using BusinessLogic.Schedule.Services;
using Data.Repository;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents(IMapper mapper)
        {
			var container = new UnityContainer();

            container.RegisterInstance(mapper);
            container.RegisterType<ITimeCalculator, TimeCalculator>();
            container.RegisterType<IBusStopRepository, BusStopRepository>();
            container.RegisterType<IRouteRepository, RouteRepository>();
            container.RegisterType<IScheduleRepository, ScheduleRepository>();
            container.RegisterType<IBusStopService, BusStopService>();
            container.RegisterType<IRouteService, RouteService>();
            container.RegisterType<IScheduleService, ScheduleService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}