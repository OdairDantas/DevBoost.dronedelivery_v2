using DevBoost.dronedelivery.Domain;
using System;
using System.Collections.Generic;

namespace DevBoost.DroneDelivery.Domain.Entities
{
    public class Cliente
    {
        public Cliente(decimal latitude, decimal longitude)
        {
            Id = Guid.NewGuid();
            Latitude = latitude;
            Longitude = longitude;
            DataHora = DateTime.Now;
            Status = true;
        }

        public Guid Id { get;private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
        public DateTime DataHora { get; private set; }
        public bool Status { get; set; }
        public List<Pedido>  Pedido { get;  set; }

        public Usuario  User { get; set; }
    }
}
