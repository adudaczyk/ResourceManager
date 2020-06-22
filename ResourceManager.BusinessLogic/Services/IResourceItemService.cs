using ResourceManager.BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.BusinessLogic.Services
{
    public interface IResourceItemService
    {
        Task<IEnumerable<ResourceItemDto>> GetResourceItems();
        Task<ResourceItemDto> GetResourceItem(string guid);
        Task AddResourceItem(ResourceItemDto userDto);
        Task UpdateResourceItem(ResourceItemDto userDto);
        Task DeleteResourceItem(string guid);
    }
}
