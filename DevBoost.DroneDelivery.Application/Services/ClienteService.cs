using DevBoost.dronedelivery.Application.DTO;
using DevBoost.DroneDelivery.Domain.Entities;
using DevBoost.DroneDelivery.Domain.Interfaces.Repositories;
using DevBoost.DroneDelivery.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevBoost.DroneDelivery.Application.Services
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<IList<Cliente>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(Cliente cliente)
        {
            //Validar ...


            
            _clienteRepository.Insert(cliente);
            await _clienteRepository.UnitOfWork.Commit();




        }
    }
}
