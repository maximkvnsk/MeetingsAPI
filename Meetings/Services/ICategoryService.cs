using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetings.Models;
using Meetings.Services.Communication;

namespace Meetings.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponce> SaveAsync(Category category);
        Task<CategoryResponce> UpdateAsync(int id, Category category);
        Task<CategoryResponce> DeleteAsync(int id);
    }
}
