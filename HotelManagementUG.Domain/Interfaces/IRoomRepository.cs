using HotelManagementUG.Domain.Entities;

namespace HotelManagementUG.Domain.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> GetRoomByIdAsync(int id);
        Task AddRoomAsync(Room room);
        Task SaveAsync();
        Task<IEnumerable<Room>> GetRoomsBySearchCriteriaAsync(HotelSearch searchCriteria);
    }
}
