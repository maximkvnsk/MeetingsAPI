using System;
using System.Collections.Generic;
using System.Linq;
using Meetings.Models;
using Meetings.Repositories;
using Meetings.Services;
using System.Threading.Tasks;

namespace Meetings.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly MeetingDBContext _context;

        public BaseRepository(MeetingDBContext context)
        {
            _context = context;
        }
    }
}
