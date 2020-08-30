using DevBoost.dronedelivery.Domain;
using DevBoost.DroneDelivery.Domain.Interfaces.Repositories;
using DevBoost.DroneDelivery.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevBoost.DroneDelivery.Application.Services
{
    public class DroneItinerarioService : IDroneItinerarioService
    {
        private readonly IDroneItinerarioRepository _droneItinerarioRepository;

        public DroneItinerarioService(IDroneItinerarioRepository droneItinerarioRepository)
        {
            _droneItinerarioRepository = droneItinerarioRepository;
        }

        public async Task<IList<DroneItinerario>> GetAll()
        {
            return await _droneItinerarioRepository.GetAll();
        }

        public async Task<DroneItinerario> GetById(Guid id)
        {
            return await _droneItinerarioRepository.GetById(id);
        }

        public async Task<DroneItinerario> GetById(int id)
        {
            return await _droneItinerarioRepository.GetById(id);
        }

        public async Task<DroneItinerario> GetDroneItinerarioPorIdDrone(int id)
        {
            return await _droneItinerarioRepository.GetDroneItinerarioPorIdDrone(id);
        }

        public async Task Insert(DroneItinerario droneItinerario)
        {
            await _droneItinerarioRepository.Insert(droneItinerario);
        }

        public async Task Update(DroneItinerario droneItinerario)
        {
            await _droneItinerarioRepository.Update(droneItinerario);
        }
        
    }
}
