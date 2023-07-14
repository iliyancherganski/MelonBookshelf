using MelonBookshelf.Business.DTOs;
using MelonBookshelf.Data.Models.Requests;
using MelonBookshelf.Models.Requests;
using Microsoft.AspNetCore.Identity;

namespace MelonBookshelf.Business.Contracts
{
    public interface IRequestService
    {
        Task<IEnumerable<ShowRequestDto>> GetAllRequests(string userId);
        IEnumerable<CategoryDto> GetAllCategories();
        Task<RequestEditDto> GetAddNewRequest();
        Task AddNewRequestAsync(RequestEditDto model, string userId);
        Task<ShowRequestDto> GetRequest(int id, string userId);
        Task UpvoteRequest(int requestId, string userId);
        Task RemoveUpvoteRequest(int requestId, string userId);
    }
}
