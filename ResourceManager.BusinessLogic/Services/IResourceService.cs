using ResourceManager.BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.BusinessLogic.Services
{
    public interface IResourceService
    {
        Task<IEnumerable<ResourceDto>> GetResources();
        Task<ResourceDto> GetResource(string guid);
        Task AddResource(ResourceDto userDto);
        Task UpdateResource(ResourceDto userDto);
        Task DeleteResource(string guid);
    }
}
