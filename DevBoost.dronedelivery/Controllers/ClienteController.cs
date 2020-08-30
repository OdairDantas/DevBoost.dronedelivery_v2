using DevBoost.dronedelivery.Application.DTO;
using DevBoost.DroneDelivery.Domain.Entities;
using DevBoost.DroneDelivery.Domain.Interfaces.Repositories;
using DevBoost.DroneDelivery.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DevBoost.dronedelivery.Controllers
{

    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteService _clienteService;
        private IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository, IClienteService clienteService)
        {
            _clienteService = clienteService;
            _clienteRepository = clienteRepository;
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult> PostCliente([FromBody]ClienteDTO objeto)
        {
            try
            {

                var usuario = _clienteRepository.GetAll().Result.FirstOrDefault(u => u.User.Username == objeto.Username);

                if (usuario != null)
                    return BadRequest();

                var cliente = new Cliente(latitude: objeto.Latitude, longitude: objeto.Longitude);
                cliente.User = new Usuario(objeto.Username, objeto.Password) { Cliente = cliente, ClienteId = cliente.Id };

                await _clienteService.Insert(cliente);

                return Ok(cliente);
            }
            catch (System.Exception ex)
            {

                return BadRequest();
            }

        }

    }
}
