using System;
using AutoMapper;
using Meetings.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetings.Resources;

namespace Meetings.Mapping
{
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveEventResource, Event>();
            CreateMap<SaveCityResource, City>();
        }
    }
}
