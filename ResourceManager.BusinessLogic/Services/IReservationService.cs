using ResourceManager.BusinessLogic.Models;
using System.Threading.Tasks;

namespace ResourceManager.BusinessLogic.Services
{
    public interface IReservationService
    {
        Task<ReservationDto> GetReservation(string guid);
        Task AddReservation(ReservationDto reservationDto);
        Task DeleteReservation(string guid);
        Task AcceptReservation(string guid);
    }
}
