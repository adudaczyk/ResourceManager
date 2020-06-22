using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceManager.EntityFrameworkCore.Models
{

    [Table("ResourceItems", Schema = "dbo")]
    public class ResourceItem : Entity
    {
        [Required]
        public string Name { get; set; }
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }
    }
}
