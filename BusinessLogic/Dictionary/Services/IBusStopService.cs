using AutoMapper;
using BusinessLogic.Dictionary.DTO;
using Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Dictionary.Services
{
    public interface IBusStopService
    {
        Task<IEnumerable<DictionaryDTO>> GetBusStopList();
    }
}
