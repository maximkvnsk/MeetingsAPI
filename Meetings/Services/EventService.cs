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
    public class EventService: IEventService
    {
		private readonly IEventRepository _eventRepository;
		private readonly IUnitOfWork _unitOfWork;

		public EventService(IEventRepository eventRepository, IUnitOfWork unitOfWork)
		{
			_eventRepository = eventRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<Event>> ListAsync()
		{
			return await _eventRepository.ListAsync();
		}

		public async Task<EventResponce> SaveAsync(Event @event)
		{
			try
			{
				await _eventRepository.AddAsync(@event);
				await _unitOfWork.CompleteAsync();

				return new EventResponce(@event);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new EventResponce($"An error occurred when saving the @event: {ex.Message}");
			}
		}

		public async Task<EventResponce> UpdateAsync(int id, Event @event)
		{
			var existingEvent = await _eventRepository.FindByIdAsync(id);

			if (existingEvent == null)
				return new EventResponce("Event not found.");

			existingEvent.Title = @event.Title;
			existingEvent.Description = @event.Description;
			existingEvent.CityId = @event.CityId;
			existingEvent.CategoryId = @event.CategoryId;

			try
			{
				_eventRepository.Update(existingEvent);
				await _unitOfWork.CompleteAsync();

				return new EventResponce(existingEvent);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new EventResponce($"An error occurred when updating the @event: {ex.Message}");
			}
		}

		public async Task<EventResponce> DeleteAsync(int id)
		{
			var existingEvent = await _eventRepository.FindByIdAsync(id);

			if (existingEvent == null)
				return new EventResponce("Event not found.");

			try
			{
				_eventRepository.Remove(existingEvent);
				await _unitOfWork.CompleteAsync();

				return new EventResponce(existingEvent);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new EventResponce($"An error occurred when deleting the @event: {ex.Message}");
			}
		}
	}
}
