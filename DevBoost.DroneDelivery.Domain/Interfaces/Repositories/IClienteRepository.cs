using DevBoost.DroneDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevBoost.DroneDelivery.Domain.Interfaces.Repositories
{
    public interface IClienteRepository:IDisposable
    {
        Task<IList<Cliente>> GetAll();
        Task<Cliente> GetById(Guid id);
        Task<Cliente> GetById(int id);
        void Insert(Cliente entity);
        void Update(Cliente entity);
        void Delete(Cliente entity);

        IUnitOfWork UnitOfWork { get; }
    }
}
