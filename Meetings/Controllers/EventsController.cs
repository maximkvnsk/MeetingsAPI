using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Meetings.Models;
using Meetings.Services;
using AutoMapper;
using Meetings.Resources;
using Meetings.Extensions;
using System.Linq;
using System.Threading.Tasks;



namespace Meetings.Controllers
{
    [Route("/api/[controller]")]
    public class EventsController: Controller
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventsController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EventResource>> ListAsync()
        {
            var events = await _eventService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveEventResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var @event = _mapper.Map<SaveEventResource, Event>(resource);
            var result = await _eventService.SaveAsync(@event);

            if (!result.Success)
                return BadRequest(result.Message);

            var eventResource = _mapper.Map<Event, EventResource>(result.Event);
            return Ok(eventResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEventResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var @event = _mapper.Map<SaveEventResource, Event>(resource);
            var result = await _eventService.UpdateAsync(id, @event);

            if (!result.Success)
                return BadRequest(result.Message);

            var eventResource = _mapper.Map<Event, EventResource>(result.Event);
            return Ok(eventResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _eventService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var eventResource = _mapper.Map<Event, EventResource>(result.Event);
            return Ok(eventResource);
        }


    }
}
