using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBoost.dronedelivery.Application.DTO
{
    public class ClienteDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

    }
}
