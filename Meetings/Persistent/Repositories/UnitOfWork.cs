using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetings.Repositories;
using Meetings.Models;

namespace Meetings.Persistent.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MeetingDBContext _context;

        public UnitOfWork(MeetingDBContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
