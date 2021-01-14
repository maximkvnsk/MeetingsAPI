using System;
using System.Collections.Generic;
using System.Linq;
using Meetings.Models;
using System.Threading.Tasks;

namespace Meetings.Services.Communication
{
    public class CategoryResponce : BaseResponse
    {
        public Category Category { get; private set; }

        private CategoryResponce(bool success, string message, Category category) : base(success, message)
        {
            Category = category;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public CategoryResponce(Category category) : this(true, string.Empty, category)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CategoryResponce(string message) : this(false, message, null)
        { }
    }
}
