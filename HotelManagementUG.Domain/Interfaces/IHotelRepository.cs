using HotelManagementUG.Domain.Entities;

namespace HotelManagementUG.Domain.Interfaces
{
    public interface IHotelRepository
    {
        Task<Hotel> GetHotelByIdAsync(int id);
        Task AddHotelAsync(Hotel hotel);
        Task SaveAsync();
        Task DeleteHotelAsync(int id);
    }
}
