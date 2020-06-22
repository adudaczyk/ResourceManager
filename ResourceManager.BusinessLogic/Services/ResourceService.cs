using AutoMapper;
using ResourceManager.BusinessLogic.Models;
using ResourceManager.EntityFrameworkCore.Models;
using ResourceManager.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.BusinessLogic.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IMapper _mapper;

        public ResourceService(IResourceRepository resourceRepository, IMapper mapper)
        {
            _resourceRepository = resourceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResourceDto>> GetResources()
        {
            var resources = await _resourceRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ResourceDto>>(resources);
        }

        public async Task<ResourceDto> GetResource(string guid)
        {
            var resource = await _resourceRepository.GetResourceByGuid(guid);

            return _mapper.Map<ResourceDto>(resource);
        }

        public async Task AddResource(ResourceDto resourceDto)
        {
            var resource = _mapper.Map<Resource>(resourceDto);

            resource.Guid = Guid.NewGuid();
            resource.CreationDate = DateTime.Now;

            _resourceRepository.Add(resource);
            await _resourceRepository.SaveChangesAsync();
        }

        public async Task UpdateResource(ResourceDto resourceDto)
        {
            var resource = await _resourceRepository.GetResourceByGuid(resourceDto.Guid.ToString());

            if (resource == null)
            {
                throw new KeyNotFoundException($"Cannot update Resource. Resource with guid {resource.Guid} does not exist");
            }

            _mapper.Map(resourceDto, resource);

            _resourceRepository.Update(resource);
            await _resourceRepository.SaveChangesAsync();
        }

        public async Task DeleteResource(string guid)
        {
            var resource = await _resourceRepository.GetResourceByGuid(guid);

            _resourceRepository.Delete(resource);
            await _resourceRepository.SaveChangesAsync();
        }
    }
}
