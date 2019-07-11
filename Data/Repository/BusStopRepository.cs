using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BusStopRepository: IBusStopRepository
    {
        private List<BusStop> _allBusStops;

        public BusStopRepository()
        {
            // mocking bus stop list
            _allBusStops = new List<BusStop>();
            const int BusStopCount = 10;

            for (int i = 1; i<= BusStopCount; i++)
            {
                _allBusStops.Add(new BusStop()
                {
                    Id = i,
                    Name = $"BusStop {i}"
                });
            }
        }

        public async Task<IQueryable<BusStop>> GetAll()
        {
            IQueryable<BusStop> query = _allBusStops.AsQueryable();
            return query;
        }

        public IQueryable<BusStop> FindBy(Expression<Func<BusStop, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(BusStop entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BusStop entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(BusStop entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
