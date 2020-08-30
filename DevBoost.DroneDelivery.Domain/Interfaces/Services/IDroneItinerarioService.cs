using DevBoost.dronedelivery.Domain;
using DevBoost.DroneDelivery.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace DevBoost.DroneDelivery.Domain.Interfaces.Services
{
    public interface IDroneItinerarioService 
    {
        Task<DroneItinerario> GetDroneItinerarioPorIdDrone(int id);
    }
}
