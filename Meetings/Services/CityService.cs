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
	public class CityService : ICityService
	{
		private readonly ICityRepository _cityRepository;
		private readonly IUnitOfWork _unitOfWork;

		public CityService(ICityRepository cityRepository, IUnitOfWork unitOfWork)
		{
			_cityRepository = cityRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<City>> ListAsync()
		{
			return await _cityRepository.ListAsync();
		}

		public async Task<CityResponce> SaveAsync(City city)
		{
			try
			{
				await _cityRepository.AddAsync(city);
				await _unitOfWork.CompleteAsync();

				return new CityResponce(city);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new CityResponce($"An error occurred when saving the city: {ex.Message}");
			}
		}

		public async Task<CityResponce> UpdateAsync(int id, City city)
		{
			var existingCity = await _cityRepository.FindByIdAsync(id);

			if (existingCity == null)
				return new CityResponce("City not found.");

			existingCity.Name = city.Name;
			existingCity.Country = city.Country;


			try
			{
				_cityRepository.Update(existingCity);
				await _unitOfWork.CompleteAsync();

				return new CityResponce(existingCity);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new CityResponce($"An error occurred when updating the city: {ex.Message}");
			}
		}

		public async Task<CityResponce> DeleteAsync(int id)
		{
			var existingCity = await _cityRepository.FindByIdAsync(id);

			if (existingCity == null)
				return new CityResponce("City not found.");

			try
			{
				_cityRepository.Remove(existingCity);
				await _unitOfWork.CompleteAsync();

				return new CityResponce(existingCity);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new CityResponce($"An error occurred when deleting the city: {ex.Message}");
			}
		}


	}
}



