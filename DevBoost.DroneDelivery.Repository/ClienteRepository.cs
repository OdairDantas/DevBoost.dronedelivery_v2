using DevBoost.DroneDelivery.Domain.Entities;
using DevBoost.DroneDelivery.Domain.Interfaces.Repositories;
using DevBoost.DroneDelivery.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevBoost.DroneDelivery.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly DCDroneDelivery _context;

        public ClienteRepository(DCDroneDelivery context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public async Task<IList<Cliente>> GetAll()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente> GetById(Guid id)
        {
            return await _context.Cliente.FindAsync(id);
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.Cliente.FindAsync(id);
        }

        public void Insert(Cliente entity)
        {
            _context.Cliente.Attach(entity);
            _context.Cliente.Add(entity);
            if (entity.User != null)
                _context.Usuario.Add(entity.User);
        }

        public void Update(Cliente entity)
        {
            _context.Cliente.Update(entity);
        }
        public void Delete(Cliente entity)
        {
            _context.Cliente.Attach(entity);
            _context.Cliente.Remove(entity);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
