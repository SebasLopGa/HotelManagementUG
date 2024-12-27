using HotelManagementUG.Domain.Entities;

namespace HotelManagementUG.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation> GetReservationByIdAsync(int id);
        Task AddReservationAsync(Reservation reservation);
        Task<IEnumerable<Reservation>> GetReservationsByHotelIdAsync(int hotelId);
    }
}
