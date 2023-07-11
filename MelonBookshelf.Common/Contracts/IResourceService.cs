using MelonBookshelf.Data.Models.Resources;

namespace MelonBookshelf.Common.Contracts
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>> GetAllResources();
        Task<IEnumerable<Resource>> GetAllUserResources(string userId);
    }
}
