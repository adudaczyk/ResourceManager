using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResourceManager.BusinessLogic.Models;
using ResourceManager.BusinessLogic.Services;

namespace ResourceManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        
        [HttpGet("{guid}")]
        public async Task<ReservationDto> GetReservation(string guid)
        {
            var reservation = await _reservationService.GetReservation(guid);

            return reservation;
        }
        
        [HttpPost]
        public async Task AddReservation([FromBody] ReservationDto reservationDto)
        {
            await _reservationService.AddReservation(reservationDto);
        }
        
        [HttpDelete("{guid}")]
        public async Task DeleteReservation(string guid)
        {
            await _reservationService.DeleteReservation(guid);
        }

        [HttpPut("accept-reservation/{guid}")]
        public async Task VerifyEmail(string guid)
        {
            await _reservationService.AcceptReservation(guid);
        }
    }
}
