using MelonBookshelf.Business.DTOs;
using MelonBookshelf.Data.Models.Requests;
using MelonBookshelf.Models.Requests;
using Microsoft.AspNetCore.Identity;

namespace MelonBookshelf.Business.Contracts
{
    public interface IRequestService
    {
        Task<IEnumerable<ShowRequestDto>> GetAllRequests();
        IEnumerable<CategoryDto> GetAllCategories();
        Task<RequestEditDto> GetAddNewRequest();
        Task AddNewRequestAsync(RequestEditDto model, string userId);
    }
}
