using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResourceManager.BusinessLogic.Models;
using ResourceManager.BusinessLogic.Services;

namespace ResourceManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet("GetResources")]
        public async Task<IEnumerable<ResourceDto>> GetResources()
        {
            var allResources = await _resourceService.GetResources();

            return allResources;
        }
        
        [HttpGet("{guid}")]
        public async Task<ResourceDto> GetResource(string guid)
        {
            var resource = await _resourceService.GetResource(guid);

            return resource;
        }
        
        [HttpPost]
        public async Task AddResource([FromBody] ResourceDto resourceDto)
        {
            await _resourceService.AddResource(resourceDto);
        }
        
        [HttpPut("{guid}")]
        public async Task UpdateResource(string guid, [FromBody] ResourceDto resourceDto)
        {
            resourceDto.Guid = new Guid(guid);
            await _resourceService.UpdateResource(resourceDto);
        }
        
        [HttpDelete("{guid}")]
        public async Task DeleteResource(string guid)
        {
            await _resourceService.DeleteResource(guid);
        }
    }
}
