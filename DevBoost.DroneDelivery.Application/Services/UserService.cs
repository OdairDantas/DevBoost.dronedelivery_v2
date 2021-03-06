﻿using DevBoost.DroneDelivery.Domain.Entities;
using DevBoost.DroneDelivery.Domain.Interfaces.Repositories;
using DevBoost.DroneDelivery.Domain.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace DevBoost.DroneDelivery.Application.Services
{
    public class UserService : IUserService
    {
        private IUsuarioRepository _usuarioRepository;

        public UserService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> AuthenticateAsync(string username, string password)
        {
            var users = await _usuarioRepository.GetAll();

            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

    }
}
