using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Device.Location;
using DevBoost.dronedelivery.Domain;
using DevBoost.DroneDelivery.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using DevBoost.dronedelivery.Domain.Enum;
using DevBoost.DroneDelivery.Domain.Entities;
using DevBoost.DroneDelivery.Domain.Interfaces.Repositories;

namespace DevBoost.dronedelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private readonly IPedidoService _pedidoService;
        private IUsuarioRepository _usuarioRepository;

        public PedidoController(IPedidoService pedidoService, IUsuarioRepository usuarioRepository)
        {
            _pedidoService = pedidoService;
            _usuarioRepository = usuarioRepository;
        }


        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedido()
        {
            return Ok(await _pedidoService.GetAll());
        }


        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<Pedido>> GetPedido(Guid id)
        {
            var pedido = await _pedidoService.GetById(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }



        [HttpPost, Authorize]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            string motivoRejeicaoPedido = string.Empty;
            if (!_pedidoService.IsPedidoValido(pedido, out motivoRejeicaoPedido))
                return BadRequest("Pedido rejeitado: " + motivoRejeicaoPedido);

            pedido.InformarHoraPedido(DateTime.Now);
            pedido.InformarStatus(EnumStatusPedido.AguardandoEntregador);


            var usuario = _usuarioRepository.GetAll().Result.FirstOrDefault(u => u.Username == User?.Identity?.Name);
            pedido.Cliente = usuario.Cliente;
            if (!await _pedidoService.Insert(pedido)) return BadRequest();


            return CreatedAtAction("GetPedido", new { id = pedido.Id }, pedido);
        }



    }
}
