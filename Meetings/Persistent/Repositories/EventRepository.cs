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
    public class EventRepository : BaseRepository, IEventRepository
    {
        public EventRepository(MeetingDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Event>> ListAsync()
        {
            return await _context.Event.Include(p => p.Category).ToListAsync();
        }

        public async Task AddAsync(Event @event)
        {
            await _context.Event.AddAsync(@event);
        }
        public async Task<Event> FindByIdAsync(int id)
        {
            return await _context.Event.FindAsync(id);
        }

        public void Update(Event @event)
        {
            _context.Event.Update(@event);
        }

        public void Remove(Event @event)
        {
            _context.Event.Remove(@event);
        }
    }
}
