using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceManager.EntityFrameworkCore.Models
{

    [Table("Reservations", Schema = "dbo")]
    public class Reservation : Entity
    {
        [Required]
        public int ResourceItemId { get; set; }
        public int UserId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool IsAccepted { get; set; }
    }
}
