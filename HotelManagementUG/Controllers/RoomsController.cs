using HotelManagementUG.Application;
using HotelManagementUG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementUG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly RoomService _roomService;

        public RoomsController(RoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null) return NotFound();
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom([FromBody] Room room)
        {
            await _roomService.AddRoomAsync(room);
            return CreatedAtAction(nameof(GetRoomById), new { id = room.Id }, room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] Room room)
        {
            var updatedRoom = await _roomService.UpdateRoomAsync(id, room);
            if (updatedRoom == null) return NotFound();
            return Ok(updatedRoom);
        }

        [HttpPatch("{id}/enable")]
        public async Task<IActionResult> EnableRoom(int id)
        {
            var room = await _roomService.EnableRoomAsync(id);
            if (room == null) return NotFound();
            return Ok(room);
        }

        [HttpPatch("{id}/disable")]
        public async Task<IActionResult> DisableRoom(int id)
        {
            var room = await _roomService.DisableRoomAsync(id);
            if (room == null) return NotFound();
            return Ok(room);
        }
    }
}
