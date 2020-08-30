using DevBoost.DroneDelivery.Domain.Entities;
using System.Threading.Tasks;

namespace DevBoost.DroneDelivery.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string username, string password);
    }
}
