using System;
using System.Collections.Generic;
using System.Linq;
using Meetings.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Meetings.Services.Communication
{
    public class EventResponce : BaseResponse
    {
        public Event Event { get; private set; }

        private EventResponce(bool success, string message, Event @event) : base(success, message)
        {
            Event = @event;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="event">Saved event.</param>
        /// <returns>Response.</returns>
        public EventResponce(Event @event) : this(true, string.Empty, @event)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public EventResponce(string message) : this(false, message, null)
        { }

    }
}
