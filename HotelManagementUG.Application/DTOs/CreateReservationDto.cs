using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementUG.Application.DTOs
{
    public class CreateReservationDto
    {
        public Guid RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public List<GuestDto> Guests { get; set; }
        public EmergencyContactDto EmergencyContact { get; set; }
    }

}
