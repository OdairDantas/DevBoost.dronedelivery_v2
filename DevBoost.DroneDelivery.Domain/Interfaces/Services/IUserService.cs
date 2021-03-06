﻿using DevBoost.DroneDelivery.Domain.Entities;
using System.Threading.Tasks;

namespace DevBoost.DroneDelivery.Domain.Interfaces.Services
{
    public interface IUserService
    {
       Task<Usuario> AuthenticateAsync(string username, string password);
    }
}
