using HotelManagementUG.Domain.Entities;
using HotelManagementUG.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementUG.Infrastructure.Persistence
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task AddRoomAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomsBySearchCriteriaAsync(HotelSearch searchCriteria)
        {
            return await _context.Rooms
                .Where(r => r.Hotel.City == searchCriteria.City)
                .Where(r => r.AvailableFrom <= searchCriteria.CheckInDate)
                .Where(r => r.AvailableTo >= searchCriteria.CheckOutDate)
                .Where(r => r.Capacity >= searchCriteria.NumberOfPeople)
                .ToListAsync();
        }
    }
}
