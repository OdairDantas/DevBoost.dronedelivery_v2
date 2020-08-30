using DevBoost.dronedelivery.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevBoost.DroneDelivery.Domain.Interfaces.Repositories
{
    public interface IDroneItinerarioRepository
    {
        Task<IList<DroneItinerario>> GetAll();
        Task<DroneItinerario> GetById(Guid id);
        Task<DroneItinerario> GetById(int id);
        Task<DroneItinerario> GetDroneItinerarioPorIdDrone(int id);

        Task Insert(DroneItinerario droneItinerario);
        Task Update(DroneItinerario droneItinerario);
        
        IUnitOfWork UnitOfWork { get; }
    }
}
