using DevBoost.dronedelivery.Application.DTO;
using DevBoost.DroneDelivery.Domain.Entities;
using DevBoost.DroneDelivery.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevBoost.dronedelivery.Controllers
{

    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult> PostCliente([FromBody]ClienteDTO objeto)
        {
            var cliente = new Cliente(latitude: objeto.Latitude, longitude: objeto.Longitude);
            cliente.User = new Usuario(objeto.Username, objeto.Password) { Cliente = cliente, ClienteId = cliente.Id };
            try
            {
                if (cliente == null)
                    BadRequest();

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
