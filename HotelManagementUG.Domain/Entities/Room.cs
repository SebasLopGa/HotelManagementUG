using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementUG.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Type { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Tax { get; set; }
        public string Location { get; set; }
        public bool Enabled { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public int Capacity { get; set; }

        public Hotel Hotel { get; set; }
    }
}
