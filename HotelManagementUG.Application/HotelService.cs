using HotelManagementUG.Domain.Entities;
using HotelManagementUG.Domain.Interfaces;

namespace HotelManagementUG.Application
{
    public class HotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            return await _hotelRepository.GetHotelByIdAsync(id);
        }

        public async Task AddHotelAsync(Hotel hotel)
        {
            await _hotelRepository.AddHotelAsync(hotel);
        }

        public async Task<Hotel> UpdateHotelAsync(int id, Hotel hotel)
        {
            var existingHotel = await _hotelRepository.GetHotelByIdAsync(id);
            if (existingHotel == null) return null;

            existingHotel.Name = hotel.Name;
            existingHotel.Address = hotel.Address;

            await _hotelRepository.SaveAsync();
            return existingHotel;
        }

        public async Task<bool> DeleteHotelAsync(int id)
        {
            var hotel = await _hotelRepository.GetHotelByIdAsync(id);
            if (hotel == null) return false;

            await _hotelRepository.DeleteHotelAsync(id);
            return true;
        }
    }
}
