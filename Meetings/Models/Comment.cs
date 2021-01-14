using System;
using System.Collections.Generic;

namespace Meetings.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string AuthorId { get; set; }
        public DateTime? Date { get; set; }
        public Event Event { get; set; }

    }
}
