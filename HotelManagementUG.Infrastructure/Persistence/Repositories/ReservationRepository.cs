using HotelManagementUG.Domain.Entities;
using HotelManagementUG.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementUG.Infrastructure.Persistence
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelDbContext _context;

        public ReservationRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByHotelIdAsync(int hotelId)
        {
            return await _context.Reservations
                .Where(r => r.Id == hotelId)
                .ToListAsync();
        }
    }
}
