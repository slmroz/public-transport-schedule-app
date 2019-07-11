using AutoMapper;
using BusinessLogic.Dictionary.DTO;
using Data.Model;
using Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Dictionary.Services
{
    public class RouteService : IRouteService
    {
        private IRouteRepository _repository;
        private IMapper _mapper;

        public RouteService(IRouteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // get all routes
        public async Task<IEnumerable<DictionaryDTO>> GetRouteList()
        {
            var routeList = await _repository.GetAll().ConfigureAwait(false);
            var routeDTOList = _mapper.Map<IEnumerable<Route>, List<DictionaryDTO>>(routeList);
            return routeDTOList;
        }
    }
}
