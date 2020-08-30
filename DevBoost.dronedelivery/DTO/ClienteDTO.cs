using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBoost.dronedelivery.DTO
{
    public class ClienteDTO
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}
