using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetings.Models;
using Meetings.Repositories;
using Meetings.Services;
using Microsoft.EntityFrameworkCore;

namespace Meetings.Persistent
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        public CityRepository(MeetingDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<City>> ListAsync()
        {
            return await _context.City.ToListAsync();
        }
        public async Task AddAsync(City city)
        {
            await _context.City.AddAsync(city);
        }
        public async Task<City> FindByIdAsync(int id)
        {
            return await _context.City.FindAsync(id);
        }

        public void Update(City city)
        {
            _context.City.Update(city);
        }

        public void Remove(City city)
        {
            _context.City.Remove(city);
        }
    }
}
