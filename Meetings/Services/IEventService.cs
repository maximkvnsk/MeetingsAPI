using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetings.Models;
using Meetings.Services.Communication;

namespace Meetings.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> ListAsync();
        Task<EventResponce> SaveAsync(Event @event);
        Task<EventResponce> UpdateAsync(int id, Event @event);
        Task<EventResponce> DeleteAsync(int id);
    }
}
