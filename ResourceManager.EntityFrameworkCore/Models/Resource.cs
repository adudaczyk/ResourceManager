using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceManager.EntityFrameworkCore.Models
{

    [Table("Resources", Schema = "dbo")]
    public class Resource : Entity
    {
        [Required]
        public string Name { get; set; }
        public List<ResourceItem> ResourceItems { get; set; }
    }
}
