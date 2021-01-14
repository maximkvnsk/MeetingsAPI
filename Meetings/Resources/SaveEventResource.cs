using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Meetings.Resources
{
    public class SaveEventResource
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        public string Description { get; set; }

        public int CityId { get; set; }
        public int CategoryId { get; set; }

    }
}

