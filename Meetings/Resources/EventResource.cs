using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetings.Resources
{
    public class EventResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CityId { get; set; }
        public CategoryResource Category { get; set; }
        public string Description { get; set; }
    }
}
