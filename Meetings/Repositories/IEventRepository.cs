using System;
using System.Collections.Generic;
using System.Linq;
using Meetings.Services.Communication;
using System.Threading.Tasks;
using Meetings.Models;
using Meetings.Controllers;
using Meetings.Repositories;

namespace Meetings.Services
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> ListAsync();
        Task AddAsync(Event @event);
        Task<Event> FindByIdAsync(int id);
        void Update(Event @event);
        void Remove(Event @event);
    }
}
