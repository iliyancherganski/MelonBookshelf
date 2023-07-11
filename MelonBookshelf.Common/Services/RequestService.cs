using MelonBookshelf.Common.Contracts;
using MelonBookshelf.Data;
using MelonBookshelf.Data.Models.Requests;
using MelonBookshelf.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace MelonBookshelf.Common.Services
{
    public class RequestService : IRequestService
    {
        private readonly BookshelfDbContext dbContext;
        public RequestService(BookshelfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<ResourceRequest> GetAddNewRequest()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ShowRequestDto>> GetAllRequests()
        {
            return await dbContext.ResourcesRequests
                .Select(x=> new ShowRequestDto(x, dbContext.RequestUpvotes.Select(x=>x.User.Email).ToList()))
                .ToListAsync();
        }
    }
}
