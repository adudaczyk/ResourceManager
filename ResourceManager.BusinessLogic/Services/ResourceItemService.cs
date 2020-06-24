using AutoMapper;
using ResourceManager.BusinessLogic.Models;
using ResourceManager.EntityFrameworkCore.Models;
using ResourceManager.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.BusinessLogic.Services
{
    public class ResourceItemService : IResourceItemService
    {
        private readonly IResourceItemRepository _resourceItemRepository;
        private readonly IMapper _mapper;

        public ResourceItemService(IResourceItemRepository resourceItemRepository, IMapper mapper)
        {
            _resourceItemRepository = resourceItemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResourceItemDto>> GetResourceItems()
        {
            var resourceItems = await _resourceItemRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ResourceItemDto>>(resourceItems);
        }

        public async Task<ResourceItemDto> GetResourceItem(string guid)
        {
            var resourceItem = await _resourceItemRepository.GetByGuid(guid);

            return _mapper.Map<ResourceItemDto>(resourceItem);
        }

        public async Task AddResourceItem(ResourceItemDto resourceItemDto)
        {
            var resourceItem = _mapper.Map<ResourceItem>(resourceItemDto);

            resourceItem.Guid = Guid.NewGuid();
            resourceItem.CreationDate = DateTime.Now;

            _resourceItemRepository.Add(resourceItem);
            await _resourceItemRepository.SaveChangesAsync();
        }

        public async Task UpdateResourceItem(ResourceItemDto resourceItemDto)
        {
            var resourceItem = await _resourceItemRepository.GetByGuid(resourceItemDto.Guid.ToString());

            if (resourceItem == null)
            {
                throw new KeyNotFoundException($"Cannot update Resource Item. Resource Item with guid {resourceItem.Guid} does not exist");
            }

            _mapper.Map(resourceItemDto, resourceItem);

            _resourceItemRepository.Update(resourceItem);
            await _resourceItemRepository.SaveChangesAsync();
        }

        public async Task DeleteResourceItem(string guid)
        {
            var resourceItem = await _resourceItemRepository.GetByGuid(guid);

            _resourceItemRepository.Delete(resourceItem);
            await _resourceItemRepository.SaveChangesAsync();
        }
    }
}
