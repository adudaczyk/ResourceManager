using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResourceManager.BusinessLogic.Models;
using ResourceManager.BusinessLogic.Services;

namespace ResourceItemManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceItemController : ControllerBase
    {
        private readonly IResourceItemService _resourceItemService;

        public ResourceItemController(IResourceItemService resourceItemService)
        {
            _resourceItemService = resourceItemService;
        }

        [HttpGet("get-resource-items")]
        public async Task<IEnumerable<ResourceItemDto>> GetResourceItems()
        {
            var allResourceItems = await _resourceItemService.GetResourceItems();

            return allResourceItems;
        }
        
        [HttpGet("{guid}")]
        public async Task<ResourceItemDto> GetResourceItem(string guid)
        {
            var resourceItem = await _resourceItemService.GetResourceItem(guid);

            return resourceItem;
        }
        
        [HttpPost]
        public async Task AddResourceItem([FromBody] ResourceItemDto resourceItemDto)
        {
            await _resourceItemService.AddResourceItem(resourceItemDto);
        }
        
        [HttpPut("{guid}")]
        public async Task UpdateResourceItem(string guid, [FromBody] ResourceItemDto resourceItemDto)
        {
            resourceItemDto.Guid = new Guid(guid);
            await _resourceItemService.UpdateResourceItem(resourceItemDto);
        }
        
        [HttpDelete("{guid}")]
        public async Task DeleteResourceItem(string guid)
        {
            await _resourceItemService.DeleteResourceItem(guid);
        }
    }
}
