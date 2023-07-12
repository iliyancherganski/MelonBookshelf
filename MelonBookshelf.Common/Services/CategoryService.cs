using MelonBookshelf.Business.Contracts;
using MelonBookshelf.Business.DTOs;
using MelonBookshelf.Data;
using MelonBookshelf.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MelonBookshelf.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BookshelfDbContext dbContext;
        public CategoryService(BookshelfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddNewCategory(CategoryDto model)
        {
            Category category = new Category()
            {
                CategoryName = model.Name,
            };
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
        }

        //public async Task<CategoryDto> GetAddNewCategory()
        //{
        //    return await 
        //}

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            return await dbContext.Categories.Select(c => new CategoryDto
            {
                Id = c.CategoryId,
                Name = c.CategoryName,
            }).ToListAsync();
        }
    }
}
