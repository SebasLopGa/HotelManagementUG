using HotelManagementUG.Application;
using HotelManagementUG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementUG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelSearchController : ControllerBase
    {
        private readonly HotelSearchService _hotelSearchService;

        public HotelSearchController(HotelSearchService hotelSearchService)
        {
            _hotelSearchService = hotelSearchService;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchHotels([FromBody] HotelSearch searchCriteria)
        {
            var rooms = await _hotelSearchService.SearchRoomsAsync(searchCriteria);
            if (!rooms.Any()) return NotFound();
            return Ok(rooms);
        }
    }
}
