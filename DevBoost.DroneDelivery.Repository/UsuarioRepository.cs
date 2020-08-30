using DevBoost.DroneDelivery.Domain.Entities;
using DevBoost.DroneDelivery.Domain.Interfaces.Repositories;
using DevBoost.DroneDelivery.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevBoost.DroneDelivery.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly DCDroneDelivery _context;

        public UsuarioRepository(DCDroneDelivery context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;


        public async Task<IList<Usuario>> GetAll()
        {
            return await _context.Usuario.Include(u=>u.Cliente).ToListAsync();
        }

        public async Task<Usuario> GetById(Guid id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public async Task<Usuario> GetById(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public void Insert(Usuario entity)
        {
            _context.Usuario.Attach(entity);
            _context.Usuario.Add(entity);
        }

        public void Update(Usuario entity)
        {
            _context.Usuario.Attach(entity);
            _context.Usuario.Update(entity);
        }
        public void Delete(Usuario entity)
        {
            _context.Usuario.Attach(entity);
            _context.Usuario.Remove(entity);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
