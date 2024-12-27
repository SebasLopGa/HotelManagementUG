using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementUG.Application.DTOs
{
    public class CreateRoomDto
    {
        public Guid HotelId { get; set; }
        public string Type { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Tax { get; set; }
        public string Location { get; set; }
    }

}
