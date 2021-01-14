using System;
using System.Collections.Generic;
using System.Linq;
using Meetings.Services.Communication;
using System.Threading.Tasks;
using Meetings.Models;

namespace Meetings.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> ListAsync();
        Task AddAsync(City city);
        Task<City> FindByIdAsync(int id);
        void Update(City city);
        void Remove(City city);
    }
}
