using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetings.Models;
using Meetings.Services.Communication;

namespace Meetings.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> ListAsync();
        Task<CityResponce> SaveAsync(City city);
        Task<CityResponce> UpdateAsync(int id, City city);
        Task<CityResponce> DeleteAsync(int id);
    }
}
