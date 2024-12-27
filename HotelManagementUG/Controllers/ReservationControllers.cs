using HotelManagementUG.Application;
using HotelManagementUG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementUG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationsController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            if (reservation == null) return NotFound();
            return Ok(reservation);
        }

        [HttpPost]
            public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
        {
            var createdReservation = await _reservationService.MakeReservationAsync(reservation);
            return CreatedAtAction(nameof(GetReservationById), new { id = createdReservation.Id }, createdReservation);
        }


        [HttpGet("hotel/{hotelId}")]
        public async Task<IActionResult> GetReservationsByHotelId(int hotelId)
        {
            var reservations = await _reservationService.GetReservationsByHotelIdAsync(hotelId);
            return Ok(reservations);
        }
    }
}
