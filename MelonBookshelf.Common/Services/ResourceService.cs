using MelonBookshelf.Business.Contracts;
using MelonBookshelf.Data;
using MelonBookshelf.Data.Models.Resources;
using Microsoft.EntityFrameworkCore;

namespace MelonBookshelf.Business.Services
{
    public class ResourceService : IResourceService
    {
        private readonly BookshelfDbContext dbContext;

        public ResourceService(BookshelfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Resource>> GetAllResources()
        {
            return await dbContext.Resources
                .ToListAsync();
        }

        public async Task<IEnumerable<Resource>> GetAllUserResources(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
