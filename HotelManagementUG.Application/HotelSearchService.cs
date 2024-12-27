using HotelManagementUG.Domain.Entities;
using HotelManagementUG.Domain.Interfaces;

namespace HotelManagementUG.Application
{
    public class HotelSearchService
    {
        private readonly IRoomRepository _roomRepository;

        public HotelSearchService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Room>> SearchRoomsAsync(HotelSearch searchCriteria)
        {
            var rooms = await _roomRepository.GetRoomsBySearchCriteriaAsync(searchCriteria);
            return rooms;
        }
    }
}
