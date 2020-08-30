using DevBoost.DroneDelivery.Domain.Entities;
using DevBoost.DroneDelivery.Domain.Interfaces.Repositories;
using DevBoost.DroneDelivery.Domain.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace DevBoost.DroneDelivery.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private IUsuarioRepository _usuarioRepository;

        public AuthenticationService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var users = await _usuarioRepository.GetAll();

            return users.Where(u => u.Username == username && u.Password == password).Any();
        }
    }
}
