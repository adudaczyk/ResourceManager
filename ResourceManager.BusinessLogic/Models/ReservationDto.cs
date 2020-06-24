using System;

namespace ResourceManager.BusinessLogic.Models
{
    public class ReservationDto : EntityDto
    {
        public int ResourceItemId { get; set; }
        public int UserId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool IsAccepted { get; set; }
    }
}
