using DevBoost.dronedelivery.Domain;
using DevBoost.DroneDelivery.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevBoost.DroneDelivery.Repository.Context
{
    public class DroneItinerarioRepository : IDroneItinerarioRepository
    {
        private readonly DCDroneDelivery _context;

        public DroneItinerarioRepository(DCDroneDelivery context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        

        public async Task<DroneItinerario> GetDroneItinerarioPorIdDrone(int id)
        {
            return await _context.DroneItinerario
                .AsNoTracking()
                .Include(d => d.Drone)
                .SingleOrDefaultAsync(d => d.DroneId == id);
        }

        public async Task<DroneItinerario> GetById(Guid id)
        {
            return await _context.DroneItinerario.FindAsync(id);
        }

        public async Task Insert(DroneItinerario droneItinerario)
        {
           await Task.Run(()=> _context.DroneItinerario.Add(droneItinerario));

        }

        public async Task<IList<DroneItinerario>> GetAll()
        {
            return await _context.DroneItinerario
                .AsNoTracking()
                .Include(d => d.Drone)
                .ToListAsync();
        }

        public async Task<DroneItinerario> GetById(int id)
        {
            return await _context.DroneItinerario
                .AsNoTracking()
                .Include(d => d.Drone)
                .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task Update(DroneItinerario droneItinerario)
        {
            await Task.Run(() => _context.DroneItinerario.Update(droneItinerario));
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
}
