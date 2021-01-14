using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetings.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<Event> Events { get; set; } = new List<Event>();
    }
}
