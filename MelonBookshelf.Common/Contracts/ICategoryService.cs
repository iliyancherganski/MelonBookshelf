using MelonBookshelf.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonBookshelf.Business.Contracts
{
    public interface ICategoryService
    {
        Task<bool> FindCategoryByName(string name);
        Task<IEnumerable<CategoryDto>> GetAllCategories();
        //Task<CategoryDto> GetAddNewCategory();
        Task AddNewCategory(CategoryDto model);
    }
}
