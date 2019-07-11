using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class RouteRepository: IRouteRepository
    {
        private List<Route> _allRoutes;

        public RouteRepository()
        {
            // mocking bus stop list
            _allRoutes = new List<Route>();
            const int RouteCount = 3;

            for (int i = 1; i<= RouteCount; i++)
            {
                _allRoutes.Add(new Route()
                {
                    Id = i,
                    Name = $"Route {i}"
                });
            }
        }

        public async Task<IQueryable<Route>> GetAll()
        {
            IQueryable<Route> query = _allRoutes.AsQueryable();
            return query;
        }

        public IQueryable<Route> FindBy(Expression<Func<Route, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Route entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Route entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Route entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
