using System;
using System.Collections.Generic;
using System.Linq;
using Meetings.Services.Communication;
using System.Threading.Tasks;
using Meetings.Models;
using Meetings.Controllers;
using Meetings.Repositories;

namespace Meetings.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IUnitOfWork _unitOfWork;

		public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
		{
			_categoryRepository = categoryRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<Category>> ListAsync()
		{
			return await _categoryRepository.ListAsync();
		}

		public async Task<CategoryResponce> SaveAsync(Category category)
		{
			try
			{
				await _categoryRepository.AddAsync(category);
				await _unitOfWork.CompleteAsync();

				return new CategoryResponce(category);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new CategoryResponce($"An error occurred when saving the category: {ex.Message}");
			}
		}

		public async Task<CategoryResponce> UpdateAsync(int id, Category category)
		{
			var existingCategory = await _categoryRepository.FindByIdAsync(id);

			if (existingCategory == null)
				return new CategoryResponce("Category not found.");

			existingCategory.Name = category.Name;

			try
			{
				_categoryRepository.Update(existingCategory);
				await _unitOfWork.CompleteAsync();

				return new CategoryResponce(existingCategory);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new CategoryResponce($"An error occurred when updating the category: {ex.Message}");
			}
		}

		public async Task<CategoryResponce> DeleteAsync(int id)
		{
			var existingCategory = await _categoryRepository.FindByIdAsync(id);

			if (existingCategory == null)
				return new CategoryResponce("Category not found.");

			try
			{
				_categoryRepository.Remove(existingCategory);
				await _unitOfWork.CompleteAsync();

				return new CategoryResponce(existingCategory);
			}
			catch (Exception ex)
			{
				// Do some logging stuff
				return new CategoryResponce($"An error occurred when deleting the category: {ex.Message}");
			}
		}


	}
}



