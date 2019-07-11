using AutoMapper;
using BusinessLogic.Dictionary.DTO;
using BusinessLogic.Dictionary.Services;
using Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class BusStopController : ApiController
    {
        private IBusStopService _busStopService;

        public BusStopController(
            IBusStopService busStopService)
        {
            _busStopService = busStopService;
        }

        // GET api/<controller>
        public async Task<IEnumerable<DictionaryDTO>> Get()
        {
            var retValue = await _busStopService.GetBusStopList().ConfigureAwait(false);
            return retValue;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}