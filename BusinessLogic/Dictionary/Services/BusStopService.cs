using AutoMapper;
using BusinessLogic.Dictionary.DTO;
using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dictionary.Services
{
    public class BusStopService: IBusStopService
    {
        private IBusStopRepository _repository;
        private IMapper _mapper;

        public BusStopService(IBusStopRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // get all bus stops
        public async Task<IEnumerable<DictionaryDTO>> GetBusStopList()
        {
            var busStopList = await _repository.GetAll().ConfigureAwait(false);
            var busStopDTOList = _mapper.Map<IEnumerable<BusStop>, List<DictionaryDTO>>(busStopList);
            return busStopDTOList;
        }
    }
}
