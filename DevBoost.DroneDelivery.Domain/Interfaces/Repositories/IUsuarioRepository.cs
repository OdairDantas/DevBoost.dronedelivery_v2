using DevBoost.DroneDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevBoost.DroneDelivery.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IList<Usuario>> GetAll();
        Task<Usuario> GetById(Guid id);
        Task<Usuario> GetById(int id);
        void Insert(Usuario entity);
        void Update(Usuario entity);
        void Delete(Usuario entity);

        IUnitOfWork UnitOfWork { get; }
    }
}
