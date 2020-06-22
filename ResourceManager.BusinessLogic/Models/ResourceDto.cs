using System.Collections.Generic;

namespace ResourceManager.BusinessLogic.Models
{
    public class ResourceDto : EntityDto
    {
        public string Name { get; set; }
        public List<ResourceItemDto> Items { get; set; }
        public int Owner { get; set; }
        public bool AcceptJoinRequest { get; set; }
    }
}
