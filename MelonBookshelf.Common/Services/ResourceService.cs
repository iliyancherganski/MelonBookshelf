using MelonBookshelf.Common.Contracts;
using MelonBookshelf.Data;
using MelonBookshelf.Data.Models.Resources;
using Microsoft.EntityFrameworkCore;

namespace MelonBookshelf.Common.Services
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
            return await dbContext.Resources
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
    }
}
