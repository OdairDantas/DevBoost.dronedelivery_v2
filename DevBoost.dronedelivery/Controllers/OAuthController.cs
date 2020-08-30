using DevBoost.dronedelivery.Application.DTO;
using DevBoost.DroneDelivery.Application.Services;
using DevBoost.DroneDelivery.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace DevBoost.dronedelivery.Controllers
{
    [ApiController]
    public class OAuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public OAuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UserDTO model)
        {
            var user = await _userService.AuthenticateAsync(model.UserName, model.Password);
            //HttpContext.Request.Body = null;
            if (user == null)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });

            return Ok(TokenService.GenerateToken(user));
        }
    }
}
