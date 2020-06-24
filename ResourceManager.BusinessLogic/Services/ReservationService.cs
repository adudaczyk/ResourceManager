using AutoMapper;
using ResourceManager.BusinessLogic.Models;
using ResourceManager.EntityFrameworkCore.Models;
using ResourceManager.EntityFrameworkCore.Repositories;
using System;
using System.Threading.Tasks;

namespace ResourceManager.BusinessLogic.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<ReservationDto> GetReservation(string guid)
        {
            var reservation = await _reservationRepository.GetByGuid(guid);

            return _mapper.Map<ReservationDto>(reservation);
        }

        public async Task AddReservation(ReservationDto reservationDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);

            reservation.Guid = Guid.NewGuid();
            reservation.CreationDate = DateTime.Now;
            reservation.IsAccepted = false;

            _reservationRepository.Add(reservation);
            await _reservationRepository.SaveChangesAsync();
        }

        public async Task DeleteReservation(string guid)
        {
            var reservation = await _reservationRepository.GetByGuid(guid);

            _reservationRepository.Delete(reservation);
            await _reservationRepository.SaveChangesAsync();
        }

        public async Task AcceptReservation(string guid)
        {
            var reservation = await _reservationRepository.GetByGuid(guid);
            reservation.IsAccepted = true;

            _reservationRepository.Update(reservation);
            await _reservationRepository.SaveChangesAsync();
        }
    }
}
