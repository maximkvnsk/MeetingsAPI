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
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CitiesController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CityResource>> GetAllAsync()
        {
            var categories = await _cityService.ListAsync();
            var resources = _mapper.Map<IEnumerable<City>, IEnumerable<CityResource>>(categories);
            return resources;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCityResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var city = _mapper.Map<SaveCityResource, City>(resource);
            var result = await _cityService.SaveAsync(city);

            if (!result.Success)
                return BadRequest(result.Message);

            var cityResource = _mapper.Map<City, CityResource>(result.City);
            return Ok(cityResource);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCityResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var city = _mapper.Map<SaveCityResource, City>(resource);
            var result = await _cityService.UpdateAsync(id, city);

            if (!result.Success)
                return BadRequest(result.Message);

            var cityResource = _mapper.Map<City, CityResource>(result.City);
            return Ok(cityResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _cityService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var cityResource = _mapper.Map<City, CityResource>(result.City);
            return Ok(cityResource);
        }
    }
}
