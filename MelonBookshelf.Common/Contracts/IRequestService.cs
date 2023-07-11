using MelonBookshelf.Data.Models.Requests;
using MelonBookshelf.Models.Requests;
using Microsoft.AspNetCore.Identity;

namespace MelonBookshelf.Common.Contracts
{
    public interface IRequestService
    {
        Task<IEnumerable<ShowRequestDto>> GetAllRequests();
        Task<ResourceRequest> GetAddNewRequest();
    }
}
