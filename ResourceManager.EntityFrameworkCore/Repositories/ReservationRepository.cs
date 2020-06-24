using ResourceManager.EntityFrameworkCore.Models;

namespace ResourceManager.EntityFrameworkCore.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ResourceManagerDbContext resourceManagerDbContext) : base(resourceManagerDbContext)
        {
        }
    }
}
