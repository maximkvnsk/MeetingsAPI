using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetings.Models;
using Meetings.Resources;
using AutoMapper;
namespace Meetings.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Event, EventResource>();
            CreateMap<City, CityResource>();
        }
    }
}