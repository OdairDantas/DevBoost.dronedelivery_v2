using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DevBoost.dronedelivery.Domain.Enum;
using DevBoost.dronedelivery.Domain;
using DevBoost.DroneDelivery.Domain.Interfaces.Repositories;
using DevBoost.dronedelivery.Application.DTO;

namespace DevBoost.dronedelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneController : ControllerBase
    {
        private IDroneItinerarioRepository _droneItinerarioRepository;
        private IDroneRepository _droneRepository;
        private IPedidoRepository  _pedidoRepository;

        public DroneController(IDroneItinerarioRepository droneItinerarioRepository, IDroneRepository droneRepository, IPedidoRepository pedidoRepository)
        {
            _droneItinerarioRepository = droneItinerarioRepository;
            _droneRepository = droneRepository;
            _pedidoRepository = pedidoRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SituacaoDroneDTO>>> GetDrone()
        {

            var drones = await _droneRepository.GetAll();

            IList<SituacaoDroneDTO> situacaoDrones = new List<SituacaoDroneDTO>();

            foreach (var drone in drones)
            {
                SituacaoDroneDTO situacaoDrone = new SituacaoDroneDTO();
                situacaoDrone.Drone = drone;

                var droneItinerario = _droneItinerarioRepository.GetAll().Result.SingleOrDefault(x => x.DroneId == drone.Id);

                if (droneItinerario == null)
                    situacaoDrone.StatusDrone = EnumStatusDrone.Disponivel.ToString();
                else
                    situacaoDrone.StatusDrone = droneItinerario.StatusDrone.ToString();

                var pedidos = await _pedidoRepository.GetAll();                 

                situacaoDrone.Pedidos = pedidos.Where(p => p.Drone != null && p.Status != EnumStatusPedido.Entregue && p.Drone.Id == drone.Id).ToList(); ;

                situacaoDrones.Add(situacaoDrone);
            }

            return Ok(situacaoDrones);
        }

        // GET: api/Drone/5
        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<Drone>> GetDrone(int id)
        {
            var drone = await _droneRepository.GetById(id);

            if (drone == null)
            {
                return NotFound();
            }

            return drone;
        }
    }
}
