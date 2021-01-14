using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetings.Models;
using Meetings.Repositories;
using Meetings.Services;
using Microsoft.EntityFrameworkCore;

namespace Meetings.Persistent
{
    public class CategoryRepository: BaseRepository, ICategoryRepository
    {
        public CategoryRepository(MeetingDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Category.ToListAsync();
        }
        public async Task AddAsync(Category category)
        {
            await _context.Category.AddAsync(category);
        }
        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Category.FindAsync(id);
        }

        public void Update(Category category)
        {
            _context.Category.Update(category);
        }

        public void Remove(Category category)
        {
            _context.Category.Remove(category);
        }
    }
}
