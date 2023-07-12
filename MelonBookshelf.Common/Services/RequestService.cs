using MelonBookshelf.Business.DTOs;
using MelonBookshelf.Business.Contracts;
using MelonBookshelf.Data;
using MelonBookshelf.Data.Models.Requests;
using MelonBookshelf.Models.Requests;
using Microsoft.EntityFrameworkCore;
using MelonBookshelf.Data.Models.Enums;
using MelonBookshelf.Data.Models;

namespace MelonBookshelf.Business.Services
{
    public class RequestService : IRequestService
    {
        private readonly BookshelfDbContext dbContext;
        public RequestService(BookshelfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<RequestEditDto> GetAddNewRequest()
        {
            var model = new RequestEditDto(GetAllCategories().ToList());
            return model;
        }
        public async Task AddNewRequestAsync(RequestEditDto model, string userId)
        {
            ResourceRequest rr = new ResourceRequest
            {
                UserId = userId,
                Title = model.Title,
                Author = model.Author,
                Status = RequestStatus.PendingReview,
                Priority = (RequestPriority)Enum.ToObject(typeof(RequestPriority), model.Priority),
                DateAdded = DateTime.Now,
                Justification = model.Justification
            };
            dbContext.ResourcesRequests.Add(rr);
            foreach (var categoryId in model.CategoryIds)
            {
                dbContext.CategoriesRequests.Add(new CategoryRequest
                {
                    Category = dbContext.Categories.FirstOrDefault(x=>x.CategoryId == categoryId),
                    CategoryId = categoryId,
                    ResourceRequest = rr,
                    RequestId = rr.Id
                });
            }
            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return dbContext.Categories.Select(x => new CategoryDto
            {
                Id = x.CategoryId,
                Name = x.CategoryName
            }).ToList();
        }

        public async Task<ShowRequestDto> GetRequest(int id)
        {
            var request = await dbContext.ResourcesRequests
                .FirstOrDefaultAsync(x => x.Id == id);
            var categories = new List<Category>();
            foreach (var categoryReq in await dbContext.CategoriesRequests.Where(c=>c.RequestId == request.Id).ToListAsync())
            {
                var category = await dbContext.Categories.FirstOrDefaultAsync(x=>x.CategoryId == categoryReq.CategoryId);
                categories.Add(category);
            }
            request.Categories = categories;
            return new ShowRequestDto(request, dbContext.RequestUpvotes.Where(x=>x.RequestId == id).Select(x => x.User.Email).ToList());
        }

        public async Task<IEnumerable<ShowRequestDto>> GetAllRequests()
        {
            var ids = await dbContext.ResourcesRequests.Select(x => x.Id).ToListAsync();
            var requests = new List<ShowRequestDto>();
            foreach (var id in ids)
            {
                requests.Add(await GetRequest(id)); 
            }
            return requests;
        }

        public async Task UpvoteRequest(int requestId, int userId)
        {

        }
    }
}
