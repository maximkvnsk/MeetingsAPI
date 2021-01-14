using System;
using System.Collections.Generic;
using System.Linq;
using Meetings.Models;
using System.Threading.Tasks;

namespace Meetings.Services.Communication
{
    public class CityResponce : BaseResponse
    {
        public City City { get; private set; }

        private CityResponce(bool success, string message, City city) : base(success, message)
        {
            City = city;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="city">Saved city.</param>
        /// <returns>Response.</returns>
        public CityResponce(City city) : this(true, string.Empty, city)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CityResponce(string message) : this(false, message, null)
        { }
    }
}
