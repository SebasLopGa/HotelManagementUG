using HotelManagementUG.Domain.Entities;
using HotelManagementUG.Domain.Interfaces;

namespace HotelManagementUG.Application
{
    public class RoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await _roomRepository.GetRoomByIdAsync(id);
        }

        public async Task AddRoomAsync(Room room)
        {
            await _roomRepository.AddRoomAsync(room);
        }

        public async Task<Room> UpdateRoomAsync(int id, Room room)
        {
            var existingRoom = await _roomRepository.GetRoomByIdAsync(id);
            if (existingRoom == null) return null;

            existingRoom.Id = room.Id;
            existingRoom.Type = room.Type;
            existingRoom.BasePrice = room.BasePrice;
            existingRoom.Enabled = room.Enabled;

            await _roomRepository.SaveAsync();
            return existingRoom;
        }

        public async Task<Room> EnableRoomAsync(int id)
        {
            var room = await _roomRepository.GetRoomByIdAsync(id);
            if (room == null) return null;

            room.Enabled = true;
            await _roomRepository.SaveAsync();
            return room;
        }

        public async Task<Room> DisableRoomAsync(int id)
        {
            var room = await _roomRepository.GetRoomByIdAsync(id);
            if (room == null) return null;

            room.Enabled = false;
            await _roomRepository.SaveAsync();
            return room;
        }
    }
}
