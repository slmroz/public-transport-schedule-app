using AutoMapper;
using BusinessLogic.Dictionary.DTO;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Unity;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BusStop, DictionaryDTO>();
            });
            var mapper = config.CreateMapper();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents(mapper);
        }
    }
}
