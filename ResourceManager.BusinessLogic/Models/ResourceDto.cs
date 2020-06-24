using System.Collections.Generic;

namespace ResourceManager.BusinessLogic.Models
{
    public class ResourceDto : EntityDto
    {
        public string Name { get; set; }
        public List<ResourceItemDto> ResourceItems { get; set; }
    }
}
