using System;
using System.Collections.Generic;

namespace Meetings.Models
{
    public partial class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CityId { get; set; }
        public int? CreatorId { get; set; }
        public int? CategoryId { get; set; }
        public string Description { get; set; }

        public City City { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
