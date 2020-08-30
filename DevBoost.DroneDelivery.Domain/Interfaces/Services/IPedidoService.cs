using DevBoost.dronedelivery.Domain;
using DevBoost.DroneDelivery.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevBoost.DroneDelivery.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        Task<IList<Pedido>> GetAll();
        Task<Pedido> GetById(Guid id);
        Task<Pedido> GetById(int id);
        Task<bool> Insert(Pedido entity);
        bool IsPedidoValido(Pedido pedido, out string mensagemRejeicaoPedido);
        
    }
}
